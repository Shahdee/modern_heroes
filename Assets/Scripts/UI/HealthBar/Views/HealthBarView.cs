using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : MonoBehaviour
{
    public float ScaleFactor => _canvas.ScaleFactor;

    [SerializeField] private Slider _healthSlider;
    [SerializeField] private RectTransform _rectTransform;
    
    private IUICanvas _canvas;

    public void SetCanvas(IUICanvas canvas)
    {
        _canvas = canvas;
    }

    public void SetPosition(Vector3 position)
    {
        _rectTransform.anchoredPosition = position;
    }

    public void SetSlider(float value)
    {
        _healthSlider.value = value;
    }

    public void Show(bool show)
    {
        gameObject.SetActive(show);
    }
}
