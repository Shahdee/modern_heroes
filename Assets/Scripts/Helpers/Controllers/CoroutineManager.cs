using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : ICoroutineManager
{
    private readonly CoroutineManagerVIew _view;

    public CoroutineManager()
    {
        var gameObject = new GameObject("CoroutineManager");
        _view = gameObject.AddComponent<CoroutineManagerVIew>();
    }

    public void StartCoroutine(IEnumerator routine)
    {
        _view.StartCoroutine(routine);
    }

    public void StopAllCoroutines()
    {
        _view.StopAllCoroutines();
    }

    public void StopCoroutine(IEnumerator routine)
    {
        _view.StopCoroutine(routine);
    }
}
