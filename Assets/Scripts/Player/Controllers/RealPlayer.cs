using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealPlayer : AbstractPlayer
{
    private readonly IInputController _inputController;

    public RealPlayer(EPlayerType playerType, IInputController inputController, ITeamController teamController) : base (playerType, teamController)
    {
        _inputController = inputController;
        
    }
}
