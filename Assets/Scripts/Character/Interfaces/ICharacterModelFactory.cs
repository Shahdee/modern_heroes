using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterModelFactory 
{
    ICharacterModel Create(CharacterStatData data);
}
