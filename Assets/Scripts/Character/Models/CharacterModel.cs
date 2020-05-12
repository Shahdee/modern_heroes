using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel : ICharacterModel
{
    public int Health => _currHealth;
    public int Damage => _characterData.DamagePoints;
    public ECharacterType CharacterType => _characterData.CharacterType;
    public GameObject Prefab => _characterData.Prefab;
    
    private readonly CharacterData _characterData;
    private int _currHealth;

    public CharacterModel(CharacterData characterStatData)
    {
        _characterData = characterStatData;
    }

    public void Reset()
    {
        _currHealth = _characterData.HealthPoints;
    }

    public bool isAlive()
    {
        return _currHealth > 0;
    }

    public void ReceiveDamage(int damage)
    {
        _currHealth -= damage;
        _currHealth = Mathf.Max(0, _currHealth);
    }
}
