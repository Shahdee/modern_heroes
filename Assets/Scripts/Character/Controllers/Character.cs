using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : ICharacter
{
    public event Action<ICharacter> OnDamaged;
    // public event Action<ICharacter> OnSelected;
    public ECharacterType CharacterType => _model.CharacterType;
    public int Health => _model.Health;
    private readonly ICharacterModel _model;

    GameObject _view;

    public Character(ICharacterModel model, GameObject view)
    {
        _model = model;
        _view = view;
    }

    public void ReceiveDamage(int damage)
    {
       _model.ReceiveDamage(damage);
        OnDamaged?.Invoke(this);
    }

    public void DealDamage(ICharacter character)
    {
        character.ReceiveDamage(_model.Damage);
        Debug.Log(CharacterType + " deals " + _model.Damage + " => " + character.CharacterType + " hp left " + character.Health);
    }

    public void Select()
    {
        // todo 


    }

    public void Move()
    {
        // todo 
    }

    public bool isAlive()
    {
        return _model.isAlive();
    }

    public void Reset()
    {
        _model.Reset();
    }
}
