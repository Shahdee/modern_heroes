using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameController : IGameController, IInitializable
{

    private readonly ICharacterFactory _characterFactory;
    private readonly ICharacterStatDataProvider _characterStatDataProvider;
    private readonly TeamDatabaseAsset _teamDatabaseAsset;
    private readonly IPlayerFactory _playerFactory;
    private readonly ICharacterModelFactory _characterModelFactory;
    private readonly ITeamFactory _teamFactory;
    private readonly ITeamStorage _teamStorage;

    public GameController(ICharacterFactory characterFactory, ICharacterStatDataProvider characterStatDataProvider,
                        TeamDatabaseAsset teamDatabaseAsset, IPlayerFactory playerFactory, ICharacterModelFactory characterModelFactory, 
                        ITeamFactory teamFactory, ITeamStorage teamStorage)
    {
        _characterFactory = characterFactory;
        _characterStatDataProvider = characterStatDataProvider;
        _teamDatabaseAsset = teamDatabaseAsset;
        _playerFactory = playerFactory;
        _characterModelFactory = characterModelFactory;
        _teamFactory = teamFactory;
        _teamStorage = teamStorage;
    }

    public void Initialize()
    {
        SpawnEntities();
    }

    void SpawnEntities()
    {
        foreach (var opponent in _teamDatabaseAsset.TeamData)
        {
            var squadMembers = new List<ICharacter>();

            foreach(var member in opponent.Characters)
            {
                var data = _characterStatDataProvider.GetCharacterStatData(member.CharacterType);
                var model = _characterModelFactory.Create(data);
                var character = _characterFactory.Create(model, member.CharacterView);
                squadMembers.Add(character);
            }

            var team = _teamFactory.Create(squadMembers);
            var player = _playerFactory.Create(opponent.PlayerType, team);

            _teamStorage.Add(player, team);
        }
    }
}
