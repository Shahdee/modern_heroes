using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel : ICharacterModel
{
    public int Health => _currHealth;
    public int Damage => _characterStatData.DamagePoints;
    public ECharacterType CharacterType => _characterStatData.CharacterType;

    private readonly CharacterStatData _characterStatData;
    private int _currHealth;

    public CharacterModel(CharacterStatData characterStatData)
    {
        _characterStatData = characterStatData;
    }

    public void Reset()
    {
        _currHealth = _characterStatData.HealthPoints;
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
