using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IBattleController 
{
    event Action OnBattleStart;
    event Action OnBattleEnd;
    void StartBattle();
}
