using UnityEngine;

public class ToolPage : MonoBehaviour
{
    [SerializeField] private GameObject blushBrushPrefab, eyeBrushPrefab;

    public void SpawnBlushBrush()
    {
        Instantiate(blushBrushPrefab, transform);
    }

    public void SpawnEyeBrush()
    {
        Instantiate(eyeBrushPrefab, transform);
    }

    public void ClearTool()
    {
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
