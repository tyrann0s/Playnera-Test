using DG.Tweening;
using UnityEngine;

public class FaceCream : Tool
{
    public override void OnTouch()
    {
        if (isPrepared) return;
        
        Vector3 preparePosition = (originalPosition + GameManager.Instance.CurrentCharacter.GetFacePosition()) / 2f;
        transform.DOMove(preparePosition, 1f).SetEase(Ease.OutBack);
        transform.DORotate(new Vector3(0,0,-15), 1f).SetEase(Ease.OutBack);
        isPrepared = true;
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
        GameManager.Instance.CurrentCharacter.RemoveAcne();
        isPrepared = false;
        transform.DOMove(originalPosition, .25f).SetEase(Ease.OutBack);
        transform.DORotate(new Vector3(0,0,0), .25f).SetEase(Ease.OutBack);
    }
}
