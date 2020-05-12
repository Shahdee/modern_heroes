using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamFactory : ITeamFactory
{
    private readonly IMapController _mapController;

    public TeamFactory(IMapController mapController)
    {
        _mapController = mapController;
    }

    public ITeamController Create(TeamData teamData, List<ICharacter> characters)
    {
        return new TeamController(teamData, characters, _mapController);
    }
}
