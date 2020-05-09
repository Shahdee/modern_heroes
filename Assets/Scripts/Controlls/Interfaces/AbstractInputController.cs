using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public abstract class AbstractInputController : IInputController, IUpdatable
{
    public event Action<Vector2> OnQuickTouch;
    public bool Enabled => _enabled;
    protected const float QuickTouchMaxTimeDelta = 0.5f;
    protected bool _enabled;
    protected bool _touchInProgress;

    public void CustomUpdate(float delta)
    {
        if (_touchInProgress && EventSystem.current.IsPointerOverGameObject())
        {
            _touchInProgress = false;
            return;
        }

        UpdateInput(delta);
    }

    public void SetEnabled(bool enabled)
    {
        _enabled = enabled;
    }

    protected abstract void UpdateInput(float delta);

    protected void QuickTouch(Vector2 position)
    {
        OnQuickTouch?.Invoke(position);
    }
}
