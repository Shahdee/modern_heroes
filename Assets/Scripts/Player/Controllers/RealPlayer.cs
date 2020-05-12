using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RealPlayer : AbstractPlayer, IDisposable
{

    // select unit 
        // move 
        // skip move 
            // once moved, we can't select another ally 

        // attack 
        // skip attack     

    private readonly IInputController _inputController;
    private readonly ITeamStorage _teamStorage;

    public RealPlayer(EPlayerType playerType, IInputController inputController, ITeamController teamController, ITeamStorage teamStorage) : base (playerType, teamController)
    {
        _inputController = inputController;
        _teamStorage = teamStorage;
    }

    private void OnTouch(Vector2 point)
    {
        switch(_turnPhase)
        {
            case ETurnPhase.Select:
                TrySelect(point);
            break;

            case ETurnPhase.Move:
                TryMove(point);
            break;

            case ETurnPhase.Attack:
                TryAttack(point);
            break;
        }

        // try select a character in that position 

        // ask map to give selected object 
        // if that object is my character 
            // if can be selected 
                // select it 


        // link to selected character
        //  touch to move 


        // ground or 
        // character 
            // mine 
            // enemy 
    }


    public override void StartTurn()
    {
        _inputController.OnQuickTouch += OnTouch;
        SetPhase(ETurnPhase.Select);
    }

    public override void EndTurn()
    {
        _teamController.EndTurn();
        _inputController.OnQuickTouch -= OnTouch;
        SetPhase(ETurnPhase.Wait);
    }


    private void TrySelect(Vector2 point)
    {
        TestSelect();
    }

    private void TryMove(Vector2 point)
    {
        // 


    }

    private void TryAttack(Vector2 point)
    {
        // get object on the map 
        // if it's not my team => attack 
        ICharacter characterToAttack = TestGetCharToAttack(); // tmp 

        if (! _teamController.isMyTeam(characterToAttack))
        {
            _teamController.SelectedCharacter.DealDamage(characterToAttack);
        }
    }

    ICharacter TestGetCharToAttack()
    {
        foreach(var tm in _teamStorage.AllTeams)
        {
            if (tm.Key != this)
                return tm.Value.TestCharToAttack();
        }
        return null;
    }

    ICharacter TestGetCharToSelect()
    {
        foreach(var tm in _teamStorage.AllTeams)
        {
            if (tm.Key == this)
                return tm.Value.TestCharToSelect();
        }
        return null;
    }


    void TestSelect()
    {
        // character selected on the map 

        ICharacter character = TestGetCharToSelect();

        if (_teamController.Select(character))
        {
            SetPhase(ETurnPhase.Attack);
            
            // todo  offer actions related to this character in ui 
        }
    }

    void SetPhase(ETurnPhase phase)
    {
        _turnPhase = phase;
        Debug.Log("next phase => " + phase);
    }

    public void Dispose()
    {
        _inputController.OnQuickTouch -= OnTouch;
    }

}
