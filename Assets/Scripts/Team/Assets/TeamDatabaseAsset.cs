using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(menuName = "SO/Database/TeamDatabase", fileName = "TeamDatabase")]
public class TeamDatabaseAsset : ScriptableObject
{
    [SerializeField] private List<TeamData> _teamData;
    public IReadOnlyList<TeamData> TeamData => _teamData;
}
