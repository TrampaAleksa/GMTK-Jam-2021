using UnityEngine;

public class LineRend : MonoBehaviour
{
    public Transform startPoint;
    Vector3 stopPosition;
    VisualPreview[] visualPreviews;
    private void Awake()
    {
        visualPreviews = GetComponentsInChildren<VisualPreview>();
    }

    public void SetPositions(Vector3 startPos, Vector3 stopPos)
    {
        startPoint.transform.position = startPos;
        stopPosition = stopPos;
        startPoint.LookAt(stopPos, Vector3.forward);
    }
    public void SetColors(Color color)
    {
        foreach (var item in visualPreviews)
        {
            item.SetColor(color);
        }
    }
    private void Update()
    {
        int i = 0;
        foreach (var vis in visualPreviews)
        {
            vis.transform.position = stopPosition;
            float spriteWidth = Vector3.Distance(startPoint.position, vis.transform.localPosition) / (visualPreviews.Length+1);
            vis.transform.localPosition -=Vector3.forward* (spriteWidth * (i+1));
            vis.SetWidth(spriteWidth);
            vis.SetValue(Test.Instance.freqband[i]);
            i++;
        }
    }
}
