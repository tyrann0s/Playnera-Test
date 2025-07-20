using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Character : MonoBehaviour
{
    private CircleCollider2D faceCollider;
    
    [SerializeField] private SpriteRenderer acneBlush;

    [SerializeField] private SpriteRenderer eyeShadow01,
        eyeShadow02,
        eyeShadow03,
        eyeShadow04,
        eyeShadow05,
        eyeShadow06,
        eyeShadow07,
        eyeShadow08,
        eyeShadow09;
    private Dictionary<SpriteRenderer, int> eyeShadows = new Dictionary<SpriteRenderer, int>();

    [SerializeField] private SpriteRenderer lipStick01,
        lipStick02,
        lipStick03,
        lipStick04,
        lipStick05,
        lipStick06;
    private Dictionary<SpriteRenderer, int> lipSticks = new Dictionary<SpriteRenderer, int>();
    
    private SpriteRenderer previousEyeShadow, previousLipStick;

    private void Start()
    {
        faceCollider = GetComponent<CircleCollider2D>();
        
        eyeShadows.Add(eyeShadow01, 1);
        eyeShadows.Add(eyeShadow02, 2);
        eyeShadows.Add(eyeShadow03, 3);
        eyeShadows.Add(eyeShadow04, 4);
        eyeShadows.Add(eyeShadow05, 5);
        eyeShadows.Add(eyeShadow06, 6);
        eyeShadows.Add(eyeShadow07, 7);
        eyeShadows.Add(eyeShadow08, 8);
        eyeShadows.Add(eyeShadow09, 9);
        
        lipSticks.Add(lipStick01, 1);
        lipSticks.Add(lipStick02, 2);
        lipSticks.Add(lipStick03, 3);
        lipSticks.Add(lipStick04, 4);
        lipSticks.Add(lipStick05, 5);
        lipSticks.Add(lipStick06, 6);
        
        ChangeEyeShadow(4);
        RemoveAcne();
        ChangeLipStick(3);
    }

    public void RemoveAcne()
    {
        acneBlush.gameObject.SetActive(false);
    }
    
    public void ChangeEyeShadow(int colorIndex)
    {
        if (previousEyeShadow)
        {
            previousEyeShadow.gameObject.SetActive(false);
        }
        
        SpriteRenderer sr = eyeShadows.FirstOrDefault(x => x.Value == colorIndex).Key;

        if (!sr)
        {
            Debug.LogError("No sprite found for color index: " + colorIndex);
            return;       
        }
        
        sr.gameObject.SetActive(true);
        previousEyeShadow = sr;
    }
    
    public void ChangeLipStick(int colorIndex)
    {
        if (previousLipStick)
        {
            previousLipStick.gameObject.SetActive(false);
        }
        
        SpriteRenderer sr = lipSticks.FirstOrDefault(x => x.Value == colorIndex).Key;
        
        if (!sr)
        {
            Debug.LogError("No sprite found for color index: " + colorIndex);
            return;       
        }
        
        sr.gameObject.SetActive(true);
        
        previousLipStick = sr;
    }

    
    public void ResetMakeUp()
    {
        if (previousEyeShadow) previousEyeShadow.gameObject.SetActive(false);
        if (previousLipStick) previousLipStick.gameObject.SetActive(false);
        acneBlush.gameObject.SetActive(true);
    }
    
    public Vector3 GetFacePosition()
    {
        return faceCollider.bounds.min;
    }
}
