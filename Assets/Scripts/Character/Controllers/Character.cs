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
    public CharacterView CharacterView {get;}

    private readonly ICharacterModel _model;

    public Character(ICharacterModel model, CharacterView view)
    {
        _model = model;
        CharacterView = view;
    }

    public void ReceiveDamage(int damage)
    {
       _model.ReceiveDamage(damage);

        if (isAlive())
            CharacterView.Blink();
        else
            CharacterView.SetActive(false);

        OnDamaged?.Invoke(this);
    }

    public void DealDamage(ICharacter character)
    {
        character.ReceiveDamage(_model.Damage);
        Debug.Log(CharacterType + " deals " + _model.Damage + " => " + character.CharacterType + " hp left " + character.Health);
    }

    public void Select(bool select)
    {   
        CharacterView.Highlight(select);
    }

    public void Move(Vector3 position)
    {
        CharacterView.transform.position = position;
    }

    public bool isAlive()
    {
        return _model.isAlive();
    }

    public void Reset()
    {
        _model.Reset();
        CharacterView.SetActive(true);
    }
}
