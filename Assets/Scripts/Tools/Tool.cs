using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public abstract class Tool : MonoBehaviour, ITouchable
{
    protected bool isPrepared;
    protected bool isColored;
    
    protected Vector3 originalPosition;

    [SerializeField] protected Image maskImage;
    protected ToolColor toolColor;

    protected virtual void Start()
    {
        originalPosition = transform.position;
        maskImage.CrossFadeAlpha(0, 0, true);
    }

    public virtual void OnTouch()
    {
        if (isPrepared) return;
        
        transform.DOMove(GameManager.Instance.CurrentCharacter.GetPrepPosition(), 1f).SetEase(Ease.OutBack);
        transform.DORotate(new Vector3(0,0,-15), 1f).SetEase(Ease.OutBack);
        isPrepared = true;
    }

    public virtual void OnDrag(Vector3 position)
    {
        if (!isPrepared) return;
        
        transform.position = position;
    }

    public virtual void OnRelease(Vector3 position)
    {
        if (!isPrepared) return;

        Collider2D collider = GetComponent < Collider2D>();
        
        collider.enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
        collider.enabled = true;

        if (hit.collider)
        {
            var character = hit.collider.GetComponent<Character>();
            if (character && isColored)
            {
                DOTween.Sequence().Append(transform.DOShakePosition(.5f, 25f, 10, 90, false, true))
                    .OnComplete(OnFinish);
                return;
            }
            
            toolColor = hit.collider.GetComponent<ToolColor>();
            if (toolColor && !isColored)
            {
                DOTween.Sequence().Append(transform.DOShakePosition(.5f, 25f, 10, 90, false, true))
                    .OnComplete(OnFinish);
                SetToolColor(toolColor);
            }
        }
    }

    protected void SetToolColor(ToolColor color)
    {
        toolColor = color;
        maskImage.color = toolColor.GetColor();
        maskImage.CrossFadeAlpha(.5f, 0, true);
    }

    protected void ClearToolColor()
    {
        toolColor = null;
        maskImage.color = Color.white;
        maskImage.CrossFadeAlpha(0, 0, true);
    }

    public abstract void OnFinish();
}
