using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : AbstractPlayer
{
    private readonly ITeamStorage _teamStorage;
    private readonly ICoroutineManager _coroutineManager;
    private readonly IMapController _mapController;
    private static float _stepGranularity = 0.25f;
    private static float _aiResponseDelay = 0.5f;
    private static float _aiChanceToSkip = 0.25f;

    public AIPlayer(EPlayerType playerType, ITeamController teamController, ITeamStorage teamStorage,
            ICoroutineManager coroutineManager, IMapController mapController) : base (playerType, teamController)
    {
        _teamStorage = teamStorage;
        _coroutineManager = coroutineManager;
        _mapController = mapController;
    }

    public override void StartTurn()
    {
        SetPhase(ETurnPhase.Select);
    }

    public override void ContinueTurn()
    {
        SetPhase(ETurnPhase.Select);
    }

    public override void EndTurn()
    {
        _teamController.EndTurn();
        SetPhase(ETurnPhase.Wait);
    }

    public override void SkipPhase()
    {
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

    protected override void SetPhase(ETurnPhase phase)
    {
        _turnPhase = phase;
        // Debug.Log("next phase => " + phase + " / " + _playerType);

        _coroutineManager.StartCoroutine(ReactToPhaseChange(_turnPhase));
    }

    private IEnumerator ReactToPhaseChange(ETurnPhase phase)
    {
        yield return new WaitForSeconds(_aiResponseDelay);

        // Debug.Log("ai response to " + _turnPhase);

        switch(_turnPhase)
        {
            case ETurnPhase.Select:
                TrySelect();
            break;

            case ETurnPhase.Move:

                if (TrySkip())
                    SkipPhase();
                else
                    TryMove();
            break;

            case ETurnPhase.Attack:
                if (TrySkip())
                    SkipPhase();
                else
                    TryAttack();
            break;

            case ETurnPhase.Wait:
                // do nothing 
            break;
        }
    }

    private bool TrySkip()
    {
        var magicNumber = UnityEngine.Random.Range(0, 1f);
        return (magicNumber < _aiChanceToSkip);
    }

    private void TrySelect()
    {
        if (_teamController.hasAvailable())
        {
            var randomCharacter = UnityEngine.Random.Range(0, _teamController.AvailableCharacters.Count);
            _teamController.Select(_teamController.AvailableCharacters[randomCharacter]);
            SetPhase(ETurnPhase.Move);
        }
        else
            Debug.LogError("couldnt select " + _turnPhase); // this shouldn't happen
    }

    private void TryMove()
    {
        foreach(var team in _teamStorage.AllTeams)
        {
            if (team.Key != this && team.Value.hasAvailable())
            {
                foreach(var character in team.Value.AvailableCharacters)
                {
                    if (TryMoveTowardsEnemy(character))
                    {
                        SetPhase(ETurnPhase.Attack);
                        return;
                    }
                }
            }
        }
        Debug.LogError("couldn't move towards enemy => skip phase");
        SkipPhase();
    }

    private bool TryMoveTowardsEnemy(ICharacter moveToCharacter)
    {
        var direction = (moveToCharacter.Position - _teamController.SelectedCharacter.Position);
        direction.Normalize();
        var moveRange = _teamController.SelectedCharacter.MoveRange;
        var teleportDistance = moveRange;
        var delta = _stepGranularity * moveRange;

        while (teleportDistance > 0)
        {
            teleportDistance -= delta;

            var teleportPoint = _teamController.SelectedCharacter.Position + direction * teleportDistance;
            var convertedPoint = _mapController.GetCellCenterPoint(teleportPoint);

            if (!PointIsOccupied(convertedPoint) && _teamController.TryMove(convertedPoint))
                return true;
        }
        return false; 
    }

    private bool PointIsOccupied(Vector3 point)
    {
        foreach(var team in _teamStorage.AllTeams)
        {
            foreach(var character in team.Value.TeamCharacters)
                if (_mapController.isSameCell(point, character.Position))
                    return true;
        }
        return false;
    }

    private void TryAttack()
    {
        foreach(var team in _teamStorage.AllTeams)
        {
            if (team.Key != this && team.Value.hasAvailable())
            {
                foreach(var character in team.Value.AvailableCharacters)
                {
                    if (_teamController.TryAttack(character))
                        return;
                }
            }
        }
        Debug.LogError("couldnt find enemy to hit"); 
        SkipPhase();
    }
}
