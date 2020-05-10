using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : IUICanvas
{
    private readonly UICanvasView _canvasView;

    public UICanvas(UICanvasView canvasView, List<IWindow> windows)
    {
        _canvasView = canvasView;

        foreach (var win in windows)
        {
            win.SetParent(_canvasView.transform);
        }
    }
}
