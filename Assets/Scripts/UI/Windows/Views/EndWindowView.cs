using UnityEngine;
using UnityEngine.UI;
using System;

public class EndWindowView : AbstractWindowView
{
    public Action OnRestart;

    [SerializeField] private Button _restartButton;

    private void Awake()
    {
        _restartButton.onClick.AddListener(StartClick);
    }

    private void StartClick()
    {
        OnRestart?.Invoke();
    }
}
