using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPage : MonoBehaviour
{
    [SerializeField] List<ToolColor> blushColors, eyeShadowColors;

    public void LoadBlushes()
    {
        SpawnColors(blushColors);
    }
    
    public void LoadEyeShadows()
    {
        SpawnColors(eyeShadowColors);
    }

    private void SpawnColors(List<ToolColor> colors)
    {
        foreach (var color in colors)
        {
            Instantiate(color, transform);
        }
    }

    public void ClearColors()
    {
        Image[] images = GetComponents<Image>();
        foreach (Image img in images)
        {
            DestroyImmediate(img);
        }
        
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
