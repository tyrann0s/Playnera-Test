using System;
using UnityEngine;

public class Page : MonoBehaviour
{
    private ColorPage colorPage;
    private ToolPage toolPage;

    private void Start()
    {
        colorPage = GetComponentInChildren<ColorPage>();
        toolPage = GetComponentInChildren<ToolPage>();
    }

    public void LoadBlushes()
    {
        colorPage.ClearColors();
        toolPage.ClearTool();
        
        colorPage.LoadBlushes();
        toolPage.SpawnBlushBrush();
    }

    public void LoadEyeShadows()
    {
        colorPage.ClearColors();
        toolPage.ClearTool();
        
        colorPage.LoadEyeShadows();
        toolPage.SpawnEyeBrush();
    }

    public void Clear()
    {
        colorPage.ClearColors();
        toolPage.ClearTool();
    }
}
