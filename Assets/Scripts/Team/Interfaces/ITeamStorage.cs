using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITeamStorage 
{
    IReadOnlyDictionary<IPlayer, ITeamController> AllTeams {get;}
    void Add(IPlayer player, ITeamController teamController);
}
