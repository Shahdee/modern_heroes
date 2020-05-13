using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class BattleWindowView : AbstractWindowView
{
    public Action OnSkipPhase;
    public Action OnSkipPlayerTurn;

    [SerializeField] private Button _btnSkipPhase;
    [SerializeField] private Button _btnSkipPlayerTurn;

    private void Awake()
    {
        _btnSkipPhase.onClick.AddListener(SkipPhaseClick);
        _btnSkipPlayerTurn.onClick.AddListener(SkipPlayerTurnClick);
    }

    public void SkipPhaseClick()
    {
        OnSkipPhase?.Invoke();
    }

    public void SkipPlayerTurnClick()
    {
        OnSkipPlayerTurn?.Invoke();
    }

    public void ShowButtons(bool show)
    {
        _btnSkipPhase.gameObject.SetActive(show);
        _btnSkipPlayerTurn.gameObject.SetActive(show);
    }
    
}
