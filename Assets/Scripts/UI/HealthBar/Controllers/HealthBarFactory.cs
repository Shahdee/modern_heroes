using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarFactory : IHealthBarFactory
{
    private readonly HealthBarView _prefab;
    private readonly Canvas _canvasParent;
    private readonly IUICanvas _uiCanvas;

    public HealthBarFactory(HealthBarView prefab, IUICanvas uiCanvas)
    {
        _prefab = prefab;
        _uiCanvas = uiCanvas;
    }

    public HealthBarView Create()
    {
        var view = Object.Instantiate(_prefab, _uiCanvas.Parent);
        view.SetCanvas(_uiCanvas);
        return view;
    }
}
