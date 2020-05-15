using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    public Vector3 AttachPoint => _attachObject.position;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Transform _attachObject;

    private static Color ActiveColor = Color.white;
    private static Color BlinkColor = Color.red;
    private static Color HighlightColor = Color.green;
    private static Color InActiveColor = Color.grey;
    private static float BlinkTime = 0.3f;

    public void Blink()
    {
        StartCoroutine(Blinking());
    }

    public void Highlight(bool on)
    {
        _renderer.material.color = on ? HighlightColor : ActiveColor;
    }

    public void SetActive(bool active)
    {
        _renderer.material.color = active ? ActiveColor : InActiveColor;
    }

    private IEnumerator Blinking()
    {
        _renderer.material.color = BlinkColor;

        yield return new WaitForSeconds(BlinkTime);

        _renderer.material.color = ActiveColor;
    }
}
