using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWindowView 
{
    void SetParent(Transform parent);

    void Open();

    void Close();
}
