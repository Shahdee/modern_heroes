using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : IBattleController
{

    // events 
        // char died (which team?)
        // player finished his turn => no character to interact are left 

        // match over 
        
            // lost / won ? 
        
        // match started 

    // team = List<ICharacter> 

    // teams 
        // subscribe to char events 
        // link to a player of that team 


    // participants 

        
    // curr player 

    // finish curr player turn 
    // give control to next player 

    // on each turn end or if a character dies 
        // check game end conditions 


    // QA 
    // how to assign player to a team 
    // how to switch controll between real player and ai ? 

    private readonly List<IPlayer> _opponents;
    private IPlayer _currentPlayer;

    public BattleController(List<IPlayer> opponents)
    {
        _opponents = opponents;
    }


}
