using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ITeamController 
{
    event Action<ICharacter, ITeamController> OnCharacterDamaged;
    event Action<ITeamController> OnAttackCanceled;
    ICharacter SelectedCharacter {get;}
    List<ICharacter> AvailableCharacters {get;}
    List<ICharacter> TeamCharacters {get;}
    void ResetTeam();
    void EndTurn();
    bool TrySelect(CharacterView view);
    bool TryMove(Vector3 position);
    void Select(ICharacter character);
    bool isMyTeam(ICharacter character);
    bool isMyTeam(CharacterView view);
    bool isTeamAlive();
    bool TryAttack(ICharacter enemy);
    ICharacter GetCharacter(CharacterView view);
    bool hasAvailable();
    void CancelAttack();
}
