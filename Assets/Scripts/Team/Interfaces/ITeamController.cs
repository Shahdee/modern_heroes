using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ITeamController 
{
    event Action<ICharacter, ITeamController> OnCharacterDamaged;
    event Action<ITeamController> OnAttackCanceled;

    ICharacter SelectedCharacter {get;}
    void ResetTeam();
    void EndTurn();
    bool TrySelect(CharacterView view);
    bool TryMove(Vector3 position);
    bool Select(ICharacter character);
    bool isMyTeam(ICharacter character);
    bool isMyTeam(CharacterView view);
    bool isTeamAlive();
    bool TryAttack(ICharacter enemy);
    ICharacter GetCharacter(CharacterView view);
    bool hasAvailable();
    void CancelAttack();
}
