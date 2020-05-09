using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterFactory : ICharacterFactory
{

    // SO 
        // Teams[] 
            // Dicitonary<ECharacterType, View> 




    public CharacterFactory()
    {

    }

    public ICharacter Create(ICharacterModel model, GameObject view)
    {
        return new Character(model, view);
    }
}
