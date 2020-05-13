using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IBattleController 
{
    event Action OnTurnStart;
    event Action OnBattleStart;
    event Action OnBattleEnd;
    void StartBattle();
    EPlayerType Winner {get;}

    void SkipPhase();
    void SkipWholeTurn();

    bool isCurrentAI();

}
