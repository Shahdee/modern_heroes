using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerFactory 
{
    IPlayer Create(EPlayerType playerType, ITeamController teamController);
}
