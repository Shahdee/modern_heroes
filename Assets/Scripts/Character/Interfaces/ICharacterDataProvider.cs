using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterDataProvider 
{
    CharacterData GetCharacterData(ECharacterType characterType);

}
