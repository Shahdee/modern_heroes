using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterStatDataProvider 
{
    CharacterStatData GetCharacterStatData(ECharacterType characterType);
}
