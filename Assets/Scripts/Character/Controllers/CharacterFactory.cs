using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterFactory : ICharacterFactory
{
    public CharacterFactory()
    {
           
    }

    public ICharacter Create(ICharacterModel model)
    {
        if (model.Prefab != null)
        {
            var obj = Object.Instantiate(model.Prefab, null);
            var view = obj.GetComponent<CharacterView>();

            return new Character(model, view);
        }
        return null;
    }
}
