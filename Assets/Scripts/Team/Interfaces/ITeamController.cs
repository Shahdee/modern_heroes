using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ITeamController 
{
    event Action<ICharacter, ITeamController> OnCharacterDamaged;

    ICharacter SelectedCharacter {get;}
    void ResetTeam();
    void EndTurn();
    bool Select(ICharacter character);
    bool isMyTeam(ICharacter character);
    bool isAlive();

    ICharacter TestCharToAttack();
    ICharacter TestCharToSelect();
}
