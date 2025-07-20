using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class EyeBrush : Tool
{
    public override void OnFinish()
    {
        if (isColored)
        {
            GameManager.Instance.CurrentCharacter.ChangeEyeShadow(toolColor.ColorIndex);
            
            transform.DOMove(originalPosition, .25f).SetEase(Ease.OutBack);
            transform.DORotate(new Vector3(0,0,0), .25f).SetEase(Ease.OutBack);
            
            ClearToolColor();
            
            isPrepared = false;
            isColored = false;
        }
        else
        {
            isColored = true;
            
            Vector3 preparePosition = (transform.position + GameManager.Instance.CurrentCharacter.GetFacePosition()) / 2f;
            transform.DOMove(preparePosition, 1f).SetEase(Ease.OutBack);
            transform.DORotate(new Vector3(0,0,-15), 1f).SetEase(Ease.OutBack);
        }
    }
}
