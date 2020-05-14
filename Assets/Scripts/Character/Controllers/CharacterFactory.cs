using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterFactory : ICharacterFactory
{
    private readonly GameObject _parent;
    public CharacterFactory()
    {
        _parent = new GameObject("Characters");
    }

    public ICharacter Create(ICharacterModel model)
    {
        if (model.Prefab != null)
        {
            var obj = Object.Instantiate(model.Prefab, _parent.transform);
            var view = obj.GetComponent<CharacterView>();

            return new Character(model, view);
        }
        return null;
    }
}
