using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IGameController 
{
    event Action<EGameState> OnGameStateChange;

    EGameState CurrentGameState {get;}

    void SetState(EGameState gameState);
}
