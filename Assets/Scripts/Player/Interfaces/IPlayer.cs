using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IPlayer 
{
    // events 

    event Action<IPlayer> PlayerEndedTurn;
    EPlayerType PlayerType {get;}
    void StartTurn();
    void ContinueTurn();
    void EndTurn();
    bool hasTurns();
    void SkipPhase();
    void SkipWholeTurn();
    bool isAlive();
}
