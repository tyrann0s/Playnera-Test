using UnityEngine;
using UnityEngine.InputSystem;

public interface ITouchable
{
    public void OnTouch();
    public void OnDrag(Vector3 position);
    public void OnRelease(Vector3 position);
}
