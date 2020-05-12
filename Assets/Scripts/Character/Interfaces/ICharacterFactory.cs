using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterFactory 
{
    ICharacter Create(ICharacterModel model);
}
