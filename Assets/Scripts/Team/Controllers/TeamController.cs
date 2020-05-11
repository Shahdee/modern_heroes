using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TeamController : ITeamController
{
    public event Action<ICharacter, ITeamController> OnCharacterDamaged;
    public ICharacter SelectedCharacter => _selectedCharacter;
    private readonly List<ICharacter> _teamCharacters;
    private readonly List<ICharacter> _deadCharacters;
    private readonly List<ICharacter> _availableCharacters;
    private readonly List<ICharacter> _madeTurnCharacters;
    private ICharacter _selectedCharacter;

    public TeamController(List<ICharacter> teamCharacters)
    {
        _teamCharacters = teamCharacters;

        _deadCharacters = new List<ICharacter>();
        _availableCharacters = new List<ICharacter>();
        _madeTurnCharacters = new List<ICharacter>();

        InitTeam();
    }

    public void ResetTeam()
    {
        _deadCharacters.Clear();
        _availableCharacters.Clear();
        _madeTurnCharacters.Clear();

        foreach(var character in _teamCharacters)
        {
            character.Reset();
            _availableCharacters.Add(character);
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

    private void InitTeam()
    {
        foreach(var character in _teamCharacters)
            character.OnDamaged += CharacterReceiveDamage;
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
