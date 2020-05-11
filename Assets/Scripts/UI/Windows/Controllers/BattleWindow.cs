using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TOOD 
// hide UI when it's AI turn



public class BattleWindow : AbstractWindow
{
    public override EWindowType WindowType => EWindowType.Battle;
    private readonly BattleWindowView _view;
    private readonly IBattleController _battleController;

    public BattleWindow(BattleWindowView view, IBattleController battleController) : base(view)
    {
        _view = view;
        _battleController = battleController;

        _view.OnSkipPhase += PhaseSkip;
        _view.OnSkipPlayerTurn += PlayerTurnSkip;

        // events 
            // character selected 
            // character deselected 
    }

    protected override void AfterOpen()
    {
        UpdateView();
    }

    private void UpdateView()
    {

    }

    private void PhaseSkip()
    {

    }

    private void PlayerTurnSkip()
    {

    }

    // player - is from my team ? 

    // team - can move, can skip, can attack ? 

    // map - able to attack 
    // map - able to move 


    // react to battle controller 

    // show skip, attack, move, - if possible 

    // send commands 
        // skip , attack, move 

    // who's turn is? 


    
}