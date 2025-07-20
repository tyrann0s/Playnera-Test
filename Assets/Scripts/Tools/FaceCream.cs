using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class FaceCream : Tool
{
    private Vector3 originalPosition;
    
    private void Start()
    {
        originalPosition = transform.position;
    }

    public override void OnTouch()
    {
        if (isPrepared) return;
        
        Vector3 preparePosition = (originalPosition + GameManager.Instance.CurrentCharacter.GetFacePosition()) / 2f;
        transform.DOMove(preparePosition, 1f).SetEase(Ease.OutBack);
        transform.DORotate(new Vector3(0,0,-15), 1f).SetEase(Ease.OutBack);
        isPrepared = true;
    }

    public override void OnDrag(Vector3 position)
    {
        if (!isPrepared) return;
        
        transform.position = position;
    }

    public override void OnFinish()
    {
        GameManager.Instance.CurrentCharacter.RemoveAcne();
        isPrepared = false;
        transform.DOMove(originalPosition, .25f).SetEase(Ease.OutBack);
        transform.DORotate(new Vector3(0,0,0), .25f).SetEase(Ease.OutBack);
    }
}
