using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ICharacter 
{
    event Action<ICharacter> OnDamaged;
    ECharacterType CharacterType {get;}
    int Health {get;}

    void Reset();

    void ReceiveDamage(int damage);
    void DealDamage(ICharacter character);
    void Select();

    void Move();

    bool isAlive();


    // show attack grid 
    // show move grid 
}
