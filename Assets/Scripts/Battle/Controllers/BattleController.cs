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
    // how to switch controll between real player and ai ? 
    // what object stars battle ?
    // when to subscribe to battle entities? 

    private readonly ITeamStorage _teamStorage;

    private IPlayer _currentPlayer;

    public BattleController(ITeamStorage teamStorage)
    {
        _teamStorage = teamStorage;


    }

    public void StartBattle()
    {
       
        SubscribeToTeams();
        
    }

    private void FinishBattle()
    {
        UnSubscribeFromTeams();
    }

    private void SubscribeToTeams()
    {
         var teams = _teamStorage.AllTeams;
    }

    private void UnSubscribeFromTeams()
    {

    }
}
