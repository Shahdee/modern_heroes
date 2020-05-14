using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamFactory : ITeamFactory
{
    private readonly IMapController _mapController;
    private readonly IRangeSphereController _rangeSphereController;

    public TeamFactory(IMapController mapController, IRangeSphereController rangeSphereController)
    {
        _mapController = mapController;
        _rangeSphereController = rangeSphereController;
    }

    public ITeamController Create(TeamData teamData, List<ICharacter> characters)
    {
        return new TeamController(teamData, characters, _mapController, _rangeSphereController);
    }
}
