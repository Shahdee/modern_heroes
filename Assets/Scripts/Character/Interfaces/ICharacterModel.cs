﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterModel 
{
    int Health {get;}
    float NormHealth {get;}
    int Damage {get;}
    float MoveRange {get;}
    float AttackRange {get;}

    ECharacterType CharacterType {get;}
    GameObject Prefab {get;}

    bool isAlive();
    void ReceiveDamage(int damage);
    void Reset();
}
