using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Tool : MonoBehaviour, ITouchable
{
    [SerializeField] protected InputActionReference touchAction, dragAction;
    
    protected bool isPrepared;
    
    public abstract void OnTouch();
    public abstract void OnDrag(Vector3 position);

    public virtual void OnRelease(Vector3 position)
    {
        if (!isPrepared) return;
        
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
    
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

    public abstract void OnFinish();
}
