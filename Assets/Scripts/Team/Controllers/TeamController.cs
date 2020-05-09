using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamController : ITeamController
{
    private readonly List<ICharacter> _teamCharacters;

    public TeamController(List<ICharacter> teamCharacters)
    {
        _teamCharacters = teamCharacters;
    }

}
