using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactory : IPlayerFactory
{
    private readonly IInputController _inputController;

    public PlayerFactory(IInputController inputController)
    {
        _inputController = inputController;
    }

   public IPlayer Create(EPlayerType playerType, ITeamController teamController)
   {
       switch(playerType)
       {
           case EPlayerType.Real:
                return new RealPlayer(playerType, _inputController, teamController);

           case EPlayerType.AI:
                return new AIPlayer(playerType, teamController);

            default:
                return null;
       }
   }
}
