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
    public float MoveRange;
    public float AttackRange;
    public GameObject Prefab;

}
