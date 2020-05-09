using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterStatDataProvider : ICharacterStatDataProvider
{
    private readonly CharacterStatDatabaseAsset _characterStatDatabaseAsset;

    public CharacterStatDataProvider(CharacterStatDatabaseAsset characterStatDatabaseAsset)
    {
        _characterStatDatabaseAsset = characterStatDatabaseAsset;
    }

    public CharacterStatData GetCharacterStatData(ECharacterType characterType)
    {
        return _characterStatDatabaseAsset.CharacterStatData.FirstOrDefault(st => st.CharacterType == characterType);
    }
}
