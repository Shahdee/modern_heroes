using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : ICharacter
{
    public ECharacterType CharacterType => ECharacterType.Healer;

    private readonly ICharacterModel _model;

    GameObject _view;

    public Character(ICharacterModel model, GameObject view)
    {
        _model = model;
        _view = view;
    }
}
