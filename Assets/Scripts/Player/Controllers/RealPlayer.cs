using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RealPlayer : AbstractPlayer, IDisposable
{
    private readonly IHitController _hitController;
    private readonly ITeamStorage _teamStorage;

    public RealPlayer(EPlayerType playerType, ITeamController teamController,
                        ITeamStorage teamStorage, IHitController hitController) : base (playerType, teamController)
    {
        _hitController = hitController;
        _teamStorage = teamStorage;

        Debug.Log( "real" + GetHashCode());
    }

    private void OnHit(RaycastHit[] hits)
    {
        switch(_turnPhase)
        {
            case ETurnPhase.Select:
                TrySelect(hits);
            break;

            case ETurnPhase.Move:
                TryMove(hits);
            break;

            case ETurnPhase.Attack:
                TryAttack(hits);
            break;
        }
    }

    public override void StartTurn()
    {
        _hitController.OnHit += OnHit;
        SetPhase(ETurnPhase.Select);
    }

    public override void ContinueTurn()
    {
        SetPhase(ETurnPhase.Select);
    }

    public override void EndTurn()
    {
        _teamController.EndTurn();
        _hitController.OnHit -= OnHit;
        SetPhase(ETurnPhase.Wait);
    }

    public override void SkipPhase()
    {
        Debug.Log("SkipPhase " + _playerType);
        switch(_turnPhase)
        {
            case ETurnPhase.Select:
                Debug.LogError("cant skip select");
            break;

            case ETurnPhase.Move:
                SetPhase(ETurnPhase.Attack);
            break;

            case ETurnPhase.Attack:
                _teamController.CancelAttack();                
            break;
        }
    }

    public override void SkipWholeTurn()
    {
        InvokeEndOfTurn();
    }

    private void TrySelect(RaycastHit[] hits)
    {
        foreach(var hit in hits)
        {
            var characterView = hit.transform.GetComponent<CharacterView>();
            if (characterView != null)
            {
                if (_teamController.TrySelect(characterView))
                {
                    SetPhase(ETurnPhase.Move);
                    break;
                }
            }
        }
    }

    private void TryMove(RaycastHit[] hits)
    {
        if (hits.Length > 1) // this is not an empty cell 
        {
            Debug.LogError("not empty cell");
            return;
        }

        foreach(var hit in hits)
        {
            var mapView = hit.transform.GetComponent<TileMapView>();
            if (mapView != null)
            {
                var cell = mapView.Grid.WorldToCell(hit.point);
                var position = mapView.TileMap.GetCellCenterWorld(cell);

                if (_teamController.TryMove(position))
                {
                    SetPhase(ETurnPhase.Attack);
                    return;
                }
            }
        }
    }

    private void TryAttack(RaycastHit[] hits)
    {
        foreach(var hit in hits)
        {
            var characterView = hit.transform.GetComponent<CharacterView>();
            if (characterView != null)
            {
                if (!_teamController.isMyTeam(characterView))
                {
                    foreach(var team in _teamStorage.AllTeams)
                    {
                        if (team.Key != this)
                        {
                            var characterToAttack = team.Value.GetCharacter(characterView);
                            if (characterToAttack != null) 
                            {
                                _teamController.TryAttack(characterToAttack);
                                return;
                            }                        
                        }
                    }
                }
            }
        }
    }


    protected override void SetPhase(ETurnPhase phase)
    {
        _turnPhase = phase;
        Debug.Log("next phase => " + phase + " / " + _playerType);
    }

    public void Dispose()
    {
        _hitController.OnHit -= OnHit;
    }
}
