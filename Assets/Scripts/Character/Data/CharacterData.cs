using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CharacterData 
{
    public ECharacterType CharacterType;
    public int HealthPoints;
    public int DamagePoints;
    public int MoveRange;
    public int AttackRange;
    public GameObject Prefab;

}
