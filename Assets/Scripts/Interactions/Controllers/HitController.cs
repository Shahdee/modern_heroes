using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HitController : IHitController
{
    public event Action<RaycastHit[]> OnHit;
    private readonly IInputController _inputController;

    public HitController(IInputController inputController)
    {
        _inputController = inputController;
        _inputController.OnQuickTouch += OnTouch;
    }

    private void OnTouch(Vector3 touch)
    {
        // Debug.Log("OnTouch " + touch);

        TryCollideSpace(touch);
    }

    private void TryCollideSpace(Vector3 touch)
    {
        var ray = Camera.main.ScreenPointToRay(touch);
        var hits3D = Physics.RaycastAll(ray);
        // foreach (var hitInfo in hits3D)
        // {
        //     Debug.Log("hit " + hitInfo.transform.name + " / " + hitInfo.point);
        // }

        if (hits3D != null && hits3D.Length > 0)
            OnHit?.Invoke(hits3D);
    } 
}
