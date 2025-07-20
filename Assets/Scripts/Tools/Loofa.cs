using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TouchPhase = UnityEngine.TouchPhase;

public class Loofa : Tool
{
      
    public override void OnTouch()
    {
        GameManager.Instance.CurrentCharacter.ResetMakeUp();
    }

    public override void OnDrag(Vector3 position)
    {

    }

    public override void OnFinish()
    {
        
    }
}
