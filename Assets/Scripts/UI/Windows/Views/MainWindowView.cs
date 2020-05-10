using UnityEngine;
using UnityEngine.UI;
using System;

public class MainWindowView : AbstractWindowView
{
    public Action OnStart;

    [SerializeField] private Button _startButton;

    private void Awake()
    {
        _startButton.onClick.AddListener(StartClick);
    }

    private void StartClick()
    {
        OnStart?.Invoke();
    }
}
