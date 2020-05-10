using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowStorage : IWindowStorage
{
    public Dictionary<EWindowType, IWindow> AllWindows => _windows;
    private readonly Dictionary<EWindowType, IWindow> _windows;

    public WindowStorage(List<IWindow> windows)
    {
        _windows = new Dictionary<EWindowType, IWindow>();

        foreach(var win in windows)
        {
            _windows.Add(win.WindowType, win);
        }
    }

    public IWindow Get(EWindowType windowType)
    {
        if (_windows.ContainsKey(windowType))
            return _windows[windowType];

        return null;
    }
}
