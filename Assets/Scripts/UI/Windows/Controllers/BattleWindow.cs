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
        _battleController.OnTurnStart += UpdateView;

        _view.OnSkipPhase += PhaseSkip;
        _view.OnSkipPlayerTurn += PlayerTurnSkip;
    }

    protected override void AfterOpen()
    {
        UpdateView();
    }

    private void UpdateView()
    {
        _view.ShowButtons(!_battleController.isCurrentAI());
    }

    private void PhaseSkip()
    {
        _battleController.SkipPhase();
    }

    private void PlayerTurnSkip()
    {
        _battleController.SkipWholeTurn();
    }

    // map - able to attack 
    // map - able to move 
}