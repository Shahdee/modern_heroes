using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPlayer : IPlayer
{
    // TODO 
    // team 
    // attack  

    // TODO Delay 
    // select a character from a team 
        // dont allow to select character which already made his turn 

    // move 
        // if possible 
    // skip 


    protected readonly ITeamController _teamController;  
    protected readonly EPlayerType _playerType;  
    protected ETurnPhase _turnPhase;

    public AbstractPlayer(EPlayerType playerType, ITeamController teamController)
    {
        _playerType = playerType;
        _teamController = teamController;
        
    }

    public abstract void StartTurn();

    public abstract void EndTurn();
}
