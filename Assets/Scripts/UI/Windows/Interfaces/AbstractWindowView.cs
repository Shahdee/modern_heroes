using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractWindowView : MonoBehaviour, IWindowView
{
    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void SetParent(Transform parent)
    {
        transform.SetParent(parent, false);
    }
}
