using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamFactory : ITeamFactory
{
    public ITeamController Create(List<ICharacter> characters)
    {
        return new TeamController(characters);
    }
}
