using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndWIndow : AbstractWindow
{
    public override EWindowType WindowType => EWindowType.End;
    private readonly EndWindowView _view;

    public EndWIndow(EndWindowView view) : base(view)
    {
        _view = view;
    }
}
