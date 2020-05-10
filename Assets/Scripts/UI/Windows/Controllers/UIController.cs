﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UIController : IUIController, IInitializable
{
    private readonly IWindowStorage _windowStorage;

    private readonly Stack<IWindow> _currWindows;

    public UIController(IWindowStorage windowStorage)
    {
        _windowStorage = windowStorage;
        _currWindows = new Stack<IWindow>();
    }

    public void Initialize()
    {
        foreach(var win in _windowStorage.AllWindows)
            win.Value.Close();

        OpenWindow(EWindowType.Main);
    }

    public void OpenWindow(EWindowType windowType)
    {
        var win = _windowStorage.Get(windowType);
        if (win == null)
            return;

        if (_currWindows.Count > 0)
        {
            var openedWindow = _currWindows.Pop();
            openedWindow.Close();
        }

        _currWindows.Push(win);
        win.Open();
    }
}
