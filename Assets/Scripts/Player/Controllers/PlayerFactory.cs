using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactory : IPlayerFactory
{
    private readonly IHitController _hitController;
    private readonly ITeamStorage _storage;
    private readonly ICoroutineManager _coroutineManager;
    private readonly IMapController _mapController;

    public PlayerFactory(IHitController hitController, ITeamStorage storage, ICoroutineManager coroutineManager, IMapController mapController)
    {
        _hitController = hitController;
        _storage = storage;
        _coroutineManager = coroutineManager;
        _mapController = mapController;
    }

   public IPlayer Create(EPlayerType playerType, ITeamController teamController)
   {
       switch(playerType)
       {
           case EPlayerType.Real:
                return new RealPlayer(playerType, teamController, _storage, _hitController);

           case EPlayerType.AI:
                return new AIPlayer(playerType, teamController, _storage, _coroutineManager, _mapController);
            default:
                return null;
       }
   }
}
