using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamStorage : ITeamStorage
{
    public IReadOnlyDictionary<IPlayer, ITeamController> AllTeams => _allTeams;
    private readonly Dictionary<IPlayer, ITeamController> _allTeams;

    public TeamStorage()
    {
        _allTeams = new Dictionary<IPlayer, ITeamController>();
    }

    public void Add(IPlayer player, ITeamController teamController)
    {
        if (!_allTeams.ContainsKey(player))
            _allTeams.Add(player, teamController);
    }

}
