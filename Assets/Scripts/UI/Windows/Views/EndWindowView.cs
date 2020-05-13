using UnityEngine;
using UnityEngine.UI;
using System;

public class EndWindowView : AbstractWindowView
{
    public Action OnRestart;

    public Text Description => _description;

    [SerializeField] private Button _restartButton;

    [SerializeField] private Text _description;

    private void Awake()
    {
        _restartButton.onClick.AddListener(StartClick);
    }

    private void StartClick()
    {
        OnRestart?.Invoke();
    }
}
