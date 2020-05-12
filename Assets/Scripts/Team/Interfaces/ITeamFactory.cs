using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITeamFactory 
{
    ITeamController Create(TeamData teamData, List<ICharacter> characters);
}
