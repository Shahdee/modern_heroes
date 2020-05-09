using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITeamFactory 
{
    ITeamController Create(List<ICharacter> characters);
}
