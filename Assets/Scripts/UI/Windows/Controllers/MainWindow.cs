using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWindow : AbstractWindow
{
    public override EWindowType WindowType => EWindowType.Main;
    private readonly MainWindowView _view;
    private readonly IBattleController _battleController;

    public MainWindow(MainWindowView view, IBattleController battleController) : base(view)
    {
        _view = view;
        _battleController = battleController;

        _view.OnStart += StartGame;
    }

    private void StartGame()
    {
        _battleController.StartBattle();
    }
}
