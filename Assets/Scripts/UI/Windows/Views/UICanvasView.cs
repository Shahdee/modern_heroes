using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvasView : MonoBehaviour
{
    // public Canvas UICanvas => _canvas;
    public float ScaleFactor => _canvas.scaleFactor;
    [SerializeField] private Canvas _canvas;
}
