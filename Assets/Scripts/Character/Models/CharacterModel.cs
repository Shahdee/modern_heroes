using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel : ICharacterModel
{
    private readonly CharacterStatData _characterStatData;

    // curr health 
    // is alive 
    // made a turn 

    public CharacterModel(CharacterStatData characterStatData)
    {
        _characterStatData = characterStatData;
    }

    public bool isAlive()
    {
        return true;
    }
    
}
