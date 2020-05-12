using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TeamController : ITeamController
{
    // todo 
    // i can get team characters using team storage later 

    public event Action<ICharacter, ITeamController> OnCharacterDamaged;
    public ICharacter SelectedCharacter => _selectedCharacter;
    private readonly List<ICharacter> _teamCharacters;
    private readonly List<ICharacter> _deadCharacters;
    private readonly List<ICharacter> _availableCharacters;
    private readonly List<ICharacter> _madeTurnCharacters;
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
        _madeTurnCharacters = new List<ICharacter>();

        foreach(var character in _teamCharacters)
            character.OnDamaged += CharacterReceiveDamage;
    }

    public void ResetTeam()
    {
        _deadCharacters.Clear();
        _availableCharacters.Clear();
        _madeTurnCharacters.Clear();

        List<Vector3> teamTiles = _mapController.GetTeamTiles(_teamData.SpawnTile);

        if (teamTiles.Count != _teamCharacters.Count)
            Debug.LogError("teamTiles.Count: " + teamTiles.Count + " != " + " _teamCharacters.Count: "+ _teamCharacters.Count + ", fix it!");

        int positionIndex = 0;

        foreach(var character in _teamCharacters)
        {
            character.Reset();
            character.Move(teamTiles[positionIndex]);
            _availableCharacters.Add(character);

            positionIndex++;
        }
    }

    public bool Select(ICharacter character)
    {
        if (!character.isAlive() || !isMyTeam(character) || !isAvailable(character))
            return false;

        _selectedCharacter = character;
        character.Select();
        
        return true;
    }

    public bool isMyTeam(ICharacter character)
    {
        return _teamCharacters.Contains(character);
    }

    public bool isAlive()
    {
        return (_deadCharacters.Count < _teamCharacters.Count);
    }

    public void EndTurn()
    {
        _selectedCharacter = null;
    }

    private bool isAvailable(ICharacter character)
    {
        return _availableCharacters.Contains(character);
    }

    private void CharacterReceiveDamage(ICharacter character)
    {
        if (! character.isAlive())
        {
            _availableCharacters.Remove(character);
            _deadCharacters.Add(character);
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
