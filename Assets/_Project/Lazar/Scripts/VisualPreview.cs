using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualPreview : MonoBehaviour
{
    private float minHeight = 1;
    private float maxHeight = 10;
    new SpriteRenderer renderer;
    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }
    public void SetValue(float value)
    {
        transform.localScale =new Vector3(transform.localScale.x, minHeight + ((maxHeight-minHeight) * value), transform.localScale.z);
    }
    public void SetWidth(float width)
    {
        transform.localScale = new Vector3(width, transform.localScale.y, transform.localScale.z);
    }

    public void SetColor(Color color)
    {
        renderer.color = color;
    }
    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
    }
}
