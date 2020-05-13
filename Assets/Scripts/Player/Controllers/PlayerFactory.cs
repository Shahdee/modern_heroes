using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactory : IPlayerFactory
{
    private readonly IHitController _hitController;
    private readonly ITeamStorage _storage;

    public PlayerFactory(IHitController hitController, ITeamStorage storage) // tmp - storage, just for tests here
    {
        _hitController = hitController;
        _storage = storage;
    }

   public IPlayer Create(EPlayerType playerType, ITeamController teamController)
   {
       switch(playerType)
       {
           case EPlayerType.Real:
                return new RealPlayer(playerType, teamController, _storage, _hitController);

           case EPlayerType.AI:
                return new AIPlayer(playerType, teamController);

            default:
                return null;
       }
   }
}
