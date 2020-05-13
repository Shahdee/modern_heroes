using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class TeamController : ITeamController
{
    // todo 
    // i can get team characters using team storage later 

    public event Action<ICharacter, ITeamController> OnCharacterDamaged;
    public event Action<ITeamController> OnAttackCanceled;
    public ICharacter SelectedCharacter => _selectedCharacter;
    private readonly List<ICharacter> _teamCharacters;
    private readonly List<ICharacter> _deadCharacters;
    private readonly List<ICharacter> _availableCharacters;
    private readonly IMapController _mapController;
    private readonly TeamData _teamData;
    private ICharacter _selectedCharacter;

    public TeamController(TeamData teamData, List<ICharacter> teamCharacters, IMapController mapController)
    {
        _teamData = teamData;
        _teamCharacters = teamCharacters;
        _mapController = mapController;

        _deadCharacters = new List<ICharacter>();
        _availableCharacters = new List<ICharacter>();

        foreach(var character in _teamCharacters)
            character.OnDamaged += CharacterReceiveDamage;
    }

    public void ResetTeam()
    {
        List<Vector3> teamTiles = _mapController.GetTeamTiles(_teamData.SpawnTile);

        if (teamTiles.Count != _teamCharacters.Count)
            Debug.LogError("teamTiles.Count: " + teamTiles.Count + " != " + " _teamCharacters.Count: "+ _teamCharacters.Count + ", fix it!");

        int positionIndex = 0;

        foreach(var character in _teamCharacters)
        {
            character.Reset();
            character.Move(teamTiles[positionIndex]);
            positionIndex++;
        }

        _deadCharacters.Clear();   
        FillAvailableCharacters();
    }

    public bool TrySelect(CharacterView view)
    {
        foreach(var character in _teamCharacters)
        {
            if(character.CharacterView == view)
            {
                 if (character.isAlive() && isAvailable(character))
                 {
                     SelectCharacter(character);
                     return true;
                 }
                 else
                    return false;
            }
        }
        return false;
    }

    public bool TryMove(Vector3 position)
    {
        _selectedCharacter.Move(position);
        return true;
    }

    public bool Select(ICharacter character)
    {
        if (!character.isAlive() || !isMyTeam(character) || !isAvailable(character))
            return false;

        Select(character);
        
        return true;
    }

    public bool isMyTeam(ICharacter character)
    {
        return _teamCharacters.Contains(character);
    }

    public bool isMyTeam(CharacterView view)
    {
        return (_teamCharacters.FirstOrDefault(ch => ch.CharacterView == view) != null);
    }

    public bool isTeamAlive()
    {
        return (_deadCharacters.Count < _teamCharacters.Count);
    }

    public void EndTurn()
    {
        DeselectCharacter();
        FillAvailableCharacters();
    }

    public ICharacter GetCharacter(CharacterView view)
    {
       var character = _teamCharacters.FirstOrDefault(ch => ch.CharacterView == view);
       return character;
    }

    public void CancelAttack()
    {
        DeselectCharacter();
        OnAttackCanceled?.Invoke(this);
    }

    public bool TryAttack(ICharacter enemy)
    {
        if (enemy.isAlive())
        {
            var chosenOne = _selectedCharacter;

            DeselectCharacter();

            chosenOne.DealDamage(enemy);
            return true;
        }
        Debug.Log("cant attack dead bodies");
        return false;
    }

    public bool hasAvailable()
    {
        return _availableCharacters.Any();
    }

    private void SelectCharacter(ICharacter character)
    {
        _selectedCharacter = character;
        _selectedCharacter.Select(true);
        _availableCharacters.Remove(_selectedCharacter);
    }

    private void FillAvailableCharacters()
    {
        _availableCharacters.Clear();

        foreach(var character in _teamCharacters)
        {
            if (character.isAlive())
                _availableCharacters.Add(character);
        }
    }

    private void DeselectCharacter()
    {
        if (_selectedCharacter!=null)
        {
            _selectedCharacter.Select(false);
            _selectedCharacter = null;
        }
    }

    private bool isAvailable(ICharacter character)
    {
        return _availableCharacters.Contains(character);
    }

    private void CharacterReceiveDamage(ICharacter character)
    {
        if (! character.isAlive())
        {   
            if (!_deadCharacters.Contains(character))
                _deadCharacters.Add(character);
            
            if (_availableCharacters.Contains(character))
                _availableCharacters.Remove(character);
        }
        
        OnCharacterDamaged?.Invoke(character, this);
    }

    public ICharacter TestCharToAttack()
    {
        return _teamCharacters[0];
    }

    public ICharacter TestCharToSelect()
    {
        return _teamCharacters[0];
    }
}
