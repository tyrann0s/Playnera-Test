using System;
using UnityEngine;


public class Book : MonoBehaviour
{
    [SerializeField] private GameObject lipstickPanel;
    [SerializeField] ToolButton toolButton;
    private Page page;

    private void Start()
    {
        page = GetComponentInChildren<Page>();
        toolButton.Initialize(this);
    }
    
    public void LoadBlushes()
    {
        page.LoadBlushes();
        lipstickPanel.SetActive(false);
    }
    
    public void LoadEyeShadows()
    {
        page.LoadEyeShadows();
        lipstickPanel.SetActive(false);
    }

    public void LoadLipsticks()
    {
        page.Clear();
        lipstickPanel.SetActive(true);
    }
}
