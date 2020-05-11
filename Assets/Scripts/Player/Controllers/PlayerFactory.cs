using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactory : IPlayerFactory
{
    private readonly IInputController _inputController;

    ITeamStorage _storage;

    public PlayerFactory(IInputController inputController, ITeamStorage storage) // tmp - storage
    {
        _inputController = inputController;

        _storage = storage;
    }

   public IPlayer Create(EPlayerType playerType, ITeamController teamController)
   {
       switch(playerType)
       {
           case EPlayerType.Real:
                return new RealPlayer(playerType, _inputController, teamController, _storage);

           case EPlayerType.AI:
                return new AIPlayer(playerType, teamController);

            default:
                return null;
       }
   }
}
