using System;
using UnityEngine;
using UnityEngine.UI;

public class ToolColor : MonoBehaviour
{
    [SerializeField] private int colorIndex;
    public int ColorIndex => colorIndex;
    
    [SerializeField] private Sprite sprite;
    [SerializeField] private Color color;
    
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        image.sprite = sprite;
    }

    public Color GetColor()
    {
        return color;
    }
}
