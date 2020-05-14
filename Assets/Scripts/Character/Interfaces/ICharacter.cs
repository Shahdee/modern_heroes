using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ICharacter 
{
    event Action<ICharacter> OnDamaged;
    ECharacterType CharacterType {get;}
    int Health {get;}
    float AttackRange {get;}
    float MoveRange {get;}
    Vector3 Position {get;}
    CharacterView CharacterView {get;}

    void Reset();

    void ReceiveDamage(int damage);
    void DealDamage(ICharacter character);
    void Select(bool select);
    void Move(Vector3 position);
    bool isAlive();
    bool isCloseToMove(Vector3 position);
    bool isCloseToHit(Vector3 position);
}
