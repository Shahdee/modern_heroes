using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class AbstractPlayer : IPlayer
{

    // move 
        // if possible 

    public event Action<IPlayer> PlayerEndedTurn;
    public EPlayerType PlayerType => _playerType;
    protected readonly ITeamController _teamController;  
    protected readonly EPlayerType _playerType;  
    protected ETurnPhase _turnPhase;

    public AbstractPlayer(EPlayerType playerType, ITeamController teamController)
    {
        _playerType = playerType;
        _teamController = teamController;
        
    }

    public abstract void StartTurn();

    public abstract void ContinueTurn();

    public abstract void EndTurn();

    public abstract void SkipPhase();

    public abstract void SkipWholeTurn();

    public bool isAlive()
    {
        return _teamController.isTeamAlive();
    }

    public bool hasTurns()
    {
        return _teamController.hasAvailable();
    }

    protected void InvokeEndOfTurn()
    {
        PlayerEndedTurn?.Invoke(this);
    }
}
