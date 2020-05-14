using System.Collections;
using UnityEngine;
using System;

public interface ICoroutineManager 
{
    void StartCoroutine(IEnumerator routine);

    void StopCoroutine(IEnumerator routine);

    void StopAllCoroutines();
}
