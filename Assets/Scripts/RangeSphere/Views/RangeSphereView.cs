using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeSphereView : MonoBehaviour
{
    
    [SerializeField] private Renderer _renderer;

    private Vector3 _tmpVector = new Vector3();

    public void Show(Vector3 position, float radius, Color color)
    {
        gameObject.SetActive(true);
        transform.position = position;

        _tmpVector.x = radius * 2;
        _tmpVector.y = transform.localScale.y;
        // _tmpVector.y = radius * 2;
        _tmpVector.z = radius * 2;

        transform.localScale = _tmpVector;
        _renderer.material.color = color;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
