using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterDataProvider : ICharacterDataProvider
{
    private readonly CharacterDatabaseAsset _characterDatabaseAsset;
    public CharacterDataProvider(CharacterDatabaseAsset characterDatabaseAsset)
    {
        _characterDatabaseAsset = characterDatabaseAsset;
    }

    public CharacterData GetCharacterData(ECharacterType type)
    {
        return _characterDatabaseAsset.Characters.FirstOrDefault(ch => ch.CharacterType == type);
    }
}
