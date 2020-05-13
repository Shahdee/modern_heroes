﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ICharacter 
{
    event Action<ICharacter> OnDamaged;
    ECharacterType CharacterType {get;}
    int Health {get;}

    CharacterView CharacterView {get;}

    void Reset();

    void ReceiveDamage(int damage);
    void DealDamage(ICharacter character);
    void Select(bool select);
    void Move(Vector3 position);
    bool isAlive();

    // show attack grid 
    // show move grid 
}
