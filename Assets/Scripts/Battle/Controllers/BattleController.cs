using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;



public class BattleController : IBattleController
{
    public event Action OnBattleStart;
    public event Action OnBattleEnd;

    // target selection 
    // actions from ui to battle controller 

    private readonly ITeamStorage _teamStorage;
    private readonly List<IPlayer> _opponents;
    private IPlayer _currentPlayer;
    private int _currentOpponentIndex;

    public BattleController(ITeamStorage teamStorage) //, IMapController mapController) 
    {
        _teamStorage = teamStorage;
        _opponents = new List<IPlayer>();
    }

    public void StartBattle()
    {
        InitTeams();

        ResetPlayers();
        ResetTeams();

        OnBattleStart?.Invoke();

        GiveControlToNextPlayer();
    }

    private void InitTeams()
    {
        foreach(var team in _teamStorage.AllTeams)
        {
            _opponents.Add(team.Key);
            team.Value.OnCharacterDamaged += CharacterDamaged;
        }
    }

    private void ResetTeams()
    {
        foreach(var team in _teamStorage.AllTeams)
            team.Value.ResetTeam();
    }

    private void ResetPlayers()
    {
        _currentOpponentIndex = -1;
    }

    private void PlayerEndedTurn()
    {
        Debug.Log("PlayerEndedTurn ");

        GiveControlToNextPlayer();
    }

    private void GiveControlToNextPlayer()
    {
        ReleasePlayer();

        _currentOpponentIndex++;
        if (_currentOpponentIndex >= _opponents.Count)
            _currentOpponentIndex = 0;

        Debug.Log("Control goes to player " + _currentOpponentIndex);

        _currentPlayer = _opponents[_currentOpponentIndex];
        _currentPlayer.StartTurn();
    }

    private void ReleasePlayer()
    {
        if ( _currentPlayer != null)
        {
            _currentPlayer.EndTurn();
            _currentPlayer = null;
        }
    }

    private void FinishBattle()
    {
        ReleasePlayer();
        OnBattleEnd?.Invoke();
    }

    private void CharacterDamaged(ICharacter character, ITeamController teamController)
    {
        if (teamController.isAlive())
        {
            PlayerEndedTurn();
        }
        else
        {
            Debug.Log("Player " + _currentOpponentIndex + " won ");

            FinishBattle();
        }
    }
}
