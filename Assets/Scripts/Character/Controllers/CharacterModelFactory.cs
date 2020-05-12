using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModelFactory : ICharacterModelFactory
{
    public CharacterModelFactory()
    {

    }

    public ICharacterModel Create(CharacterData data)
    {
        return new CharacterModel(data);
    }

}
