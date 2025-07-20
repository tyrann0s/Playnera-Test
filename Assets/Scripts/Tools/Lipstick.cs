using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lipstick : Tool
{
    private List<Lipstick> lipsticks = new();
    
    protected override void Start()
    {
        base.Start();
        toolColor = GetComponent<ToolColor>();
        lipsticks.AddRange(FindObjectsByType<Lipstick>(sortMode: FindObjectsSortMode.None));
    }

    public override void OnTouch()
    {
        base.OnTouch();

        foreach (var lipstick in lipsticks)
        {
            if (lipstick != this) lipstick.MoveBack();
        }
    }

    private void MoveBack()
    {
        transform.DOKill(true);
        transform.DOMove(originalPosition, .25f).SetEase(Ease.OutBack);
        transform.DORotate(new Vector3(0,0,0), .25f).SetEase(Ease.OutBack);
        isPrepared = false;
    }
    
    public override void OnRelease(Vector3 position)
    {
        if (!isPrepared) return;

        Collider2D collider = GetComponent < Collider2D>();
        
        collider.enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
        collider.enabled = true;

        if (hit.collider)
        {
            var character = hit.collider.GetComponent<Character>();
            if (character)
            {
                DOTween.Sequence().Append(transform.DOShakePosition(.5f, 25f, 10, 90, false, true))
                    .OnComplete(OnFinish);
            }
        }
    }

    public override void OnFinish()
    {
        GameManager.Instance.CurrentCharacter.ChangeLipStick(toolColor.ColorIndex);
            
        transform.DOMove(originalPosition, .25f).SetEase(Ease.OutBack);
        transform.DORotate(new Vector3(0,0,0), .25f).SetEase(Ease.OutBack);
            
        ClearToolColor();
            
        isPrepared = false;
    }
}
