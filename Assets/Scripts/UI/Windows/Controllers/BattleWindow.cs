using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleWindow : AbstractWindow
{
    public override EWindowType WindowType => EWindowType.Battle;
    private readonly BattleWindowView _view;

    public BattleWindow(BattleWindowView view) : base(view)
    {
        _view = view;
    }
}