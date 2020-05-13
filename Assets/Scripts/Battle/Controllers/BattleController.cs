using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;
using System.Linq;


public class BattleController : IBattleController
{
    public event Action OnTurnStart;
    public event Action OnBattleStart;
    public event Action OnBattleEnd;
    public EPlayerType Winner => _winnerPlayer.PlayerType;

    private readonly ITeamStorage _teamStorage;
    private readonly List<IPlayer> _opponents;
    private IPlayer _currentPlayer;
    private IPlayer _winnerPlayer;
    private int _currentOpponentIndex;

    public BattleController(ITeamStorage teamStorage)
    {
        _teamStorage = teamStorage;
        _opponents = new List<IPlayer>();
    }

    public void StartBattle()
    {
        InitTeams();

        ResetPlayers();
        ResetTeams();

        GiveControlToNextPlayer();

        OnBattleStart?.Invoke();
    }

    public void SkipPhase()
    {
        _currentPlayer.SkipPhase();
    }

    public void SkipWholeTurn()
    {
        PlayerEndedTurn();
    }

    public bool isCurrentAI()
    {
        return _currentPlayer.PlayerType == EPlayerType.AI;
    }

    private void InitTeams()
    {
        _opponents.Clear();

        foreach(var team in _teamStorage.AllTeams)
        {
            _opponents.Add(team.Key);
            team.Value.OnCharacterDamaged += CharacterDamaged;
            team.Value.OnAttackCanceled += AttackSkipped;
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
        _winnerPlayer = null;
    }

    private void PlayerEndedTurn()
    {
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

        OnTurnStart?.Invoke();
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
        _winnerPlayer = _currentPlayer;

        ReleasePlayer();
        ReleaseTeams();
        OnBattleEnd?.Invoke();
    }

    private void ReleaseTeams()
    {
        foreach(var team in _teamStorage.AllTeams)
            team.Value.OnCharacterDamaged -= CharacterDamaged;
    }

    private void CharacterDamaged(ICharacter character, ITeamController teamController)
    {
        if (! teamController.isTeamAlive())
            FinishBattle();
        else
            GiveChanceToPlayer();
    }

    private void AttackSkipped(ITeamController teamController)
    {
        GiveChanceToPlayer();
    }

    private void GiveChanceToPlayer()
    {
        if (_currentPlayer.hasTurns())
            _currentPlayer.ContinueTurn();
        else
        {
            PlayerEndedTurn();
        }
    }
}
