using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : ICharacter
{
    public event Action<ICharacter> OnDamaged;
    public ECharacterType CharacterType => _model.CharacterType;
    public int Health => _model.Health;
    public float AttackRange => _model.AttackRange;
    public float MoveRange => _model.MoveRange;
    public CharacterView CharacterView {get;}
    public Vector3 Position => CharacterView.transform.position;

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

    public bool isCloseToMove(Vector3 position)
    {
        return (Vector3.Distance(position, CharacterView.transform.position) <=  _model.MoveRange);
    }

    public bool isCloseToHit(Vector3 position)
    {
        return (Vector3.Distance(position, CharacterView.transform.position) <=  _model.AttackRange);
    }
}
