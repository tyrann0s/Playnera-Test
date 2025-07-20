using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GraphicRaycaster uiRaycaster;
    private Camera mainCamera;
    
    private ITouchable currentTouchable;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        
        Touch.onFingerDown += StartTouch;
        Touch.onFingerUp += StopTouch;
        Touch.onFingerMove += StartDrag;
    }

    private void OnDisable()
    {
        Touch.onFingerDown -= StartTouch;
        Touch.onFingerUp -= StopTouch;
        Touch.onFingerMove -= StartDrag;
        
        EnhancedTouchSupport.Disable();
    }

    private void StartTouch(Finger obj)
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Клик по UI элементу");
            return;
        }
        
        RaycastHit2D hit = Physics2D.Raycast(WorldPoint(obj), Vector2.zero);
    
        if (hit.collider)
        {
            currentTouchable = hit.collider.GetComponent<ITouchable>();
            currentTouchable?.OnTouch();
        }
    }

    private void StopTouch(Finger obj)
    {
        currentTouchable?.OnRelease(WorldPoint(obj));
        currentTouchable = null;
    }
    
    private void StartDrag(Finger obj)
    {
        currentTouchable?.OnDrag(WorldPoint(obj));
    }

    private Vector2 WorldPoint(Finger finger)
    {
        return mainCamera.ScreenToWorldPoint(finger.screenPosition);
    }
}
