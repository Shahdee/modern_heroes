using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

public class GameController : IGameController, IInitializable, IDisposable
{
    public event Action<EGameState> OnGameStateChange;
    public EGameState CurrentGameState => _currentGameState;

    private readonly ICharacterFactory _characterFactory;
    private readonly ICharacterDataProvider _characterDataProvider;
    private readonly TeamDatabaseAsset _teamDatabaseAsset;
    private readonly IPlayerFactory _playerFactory;
    private readonly ICharacterModelFactory _characterModelFactory;
    private readonly ITeamFactory _teamFactory;
    private readonly ITeamStorage _teamStorage;
    private readonly IUIController _uiController;
    private readonly IBattleController _battleController;
    private EGameState _currentGameState = EGameState.Lobby;
    private bool _forceSetState = true;

    public GameController(ICharacterFactory characterFactory, ICharacterDataProvider characterStatDataProvider,
                        TeamDatabaseAsset teamDatabaseAsset, IPlayerFactory playerFactory, ICharacterModelFactory characterModelFactory, 
                        ITeamFactory teamFactory, ITeamStorage teamStorage, IUIController uiController, IBattleController battleController)
    {
        _characterFactory = characterFactory;
        _characterDataProvider = characterStatDataProvider;
        _teamDatabaseAsset = teamDatabaseAsset;
        _playerFactory = playerFactory;
        _characterModelFactory = characterModelFactory;
        _teamFactory = teamFactory;
        _teamStorage = teamStorage;

        _uiController = uiController;
        _battleController = battleController;
    }

    public void Initialize()
    {
        _battleController.OnBattleEnd += BattleEnded;
        _battleController.OnBattleStart += BattleStarted;

        SpawnEntities();
        SetState(EGameState.Lobby);
    }

    public void SetState(EGameState gameState)
    {
        if (_currentGameState != gameState || _forceSetState)
        {
            _forceSetState = false;

            _currentGameState = gameState;

            SwitchGame(_currentGameState);

            OnGameStateChange?.Invoke(_currentGameState);
        }
    }

    private void SwitchGame(EGameState gameState)
    {
        switch(gameState)
        {
            case EGameState.Lobby:
                _uiController.OpenWindow(EWindowType.Main);                
            break;

            case EGameState.InBattle:
                _uiController.OpenWindow(EWindowType.Battle);
            break;

            case EGameState.BattleEnd:
                _uiController.OpenWindow(EWindowType.End);
            break;
        }   
    }

    private void SpawnEntities()
    {
        foreach (var opponent in _teamDatabaseAsset.TeamData)
        {
            var squadMembers = new List<ICharacter>();

            foreach(var charType in opponent.Characters)
            {
                var data = _characterDataProvider.GetCharacterData(charType);
                var model = _characterModelFactory.Create(data);
                var character = _characterFactory.Create(model);
                squadMembers.Add(character);
            }

            var team = _teamFactory.Create(opponent, squadMembers);
            var player = _playerFactory.Create(opponent.PlayerType, team);

            _teamStorage.Add(player, team);
        }
    }

    private void BattleStarted()
    {
        SetState(EGameState.InBattle);
    }

    private void BattleEnded()
    {
        SetState(EGameState.BattleEnd);
    }

    public void Dispose()
    {
        _battleController.OnBattleStart -= BattleStarted;
        _battleController.OnBattleEnd -= BattleEnded;
    }
}
