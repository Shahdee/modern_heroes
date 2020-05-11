using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterFactory : ICharacterFactory
{
    public CharacterFactory()
    {

    }

    public ICharacter Create(ICharacterModel model, GameObject view)
    {
        return new Character(model, view);
    }
}
