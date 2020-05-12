using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterModel 
{
    int Health {get;}
    int Damage {get;}
    ECharacterType CharacterType {get;}
    GameObject Prefab {get;}

    bool isAlive();
    void ReceiveDamage(int damage);
    void Reset();
}
