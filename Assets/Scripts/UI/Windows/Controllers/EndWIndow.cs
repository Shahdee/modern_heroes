using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndWIndow : AbstractWindow
{
    public override EWindowType WindowType => EWindowType.End;
    private readonly EndWindowView _view;
    private readonly IBattleController _battleController;

    public EndWIndow(EndWindowView view, IBattleController battleController) : base(view)
    {
        _view = view;
        _battleController = battleController;
        _view.OnRestart += StartGame;
    }

    protected override void AfterOpen()
    {
        _view.Description.text = _battleController.Winner.ToString();
    }

    private void StartGame()
    {
        _battleController.StartBattle();
    }
}
