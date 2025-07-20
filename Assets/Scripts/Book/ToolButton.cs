using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToolButton : MonoBehaviour
{
    [SerializeField] Button blushButton, eyeShadowButton, lipstickButton;
    private List<Button> buttons;
    private Book book;

    private enum ButtonType
    {
        None,
        Blush,
        EyeShadow,
        Lipstick
    }

    private ButtonType buttonType;
    
    public void Initialize(Book parentBook)
    {
        book = parentBook;
        blushButton.onClick.AddListener(BlushButtonClicked);
        eyeShadowButton.onClick.AddListener(EyeShadowButtonClicked);
        lipstickButton.onClick.AddListener(LipstickButtonClicked);
        
        buttons = new List<Button> {blushButton, eyeShadowButton, lipstickButton};
        
        // Создаем фиктивные данные события
        var pointerEventData = new PointerEventData(EventSystem.current);
            
        // Симулируем полный цикл нажатия
        ExecuteEvents.Execute(blushButton.gameObject, pointerEventData, ExecuteEvents.pointerDownHandler);
        ExecuteEvents.Execute(blushButton.gameObject, pointerEventData, ExecuteEvents.pointerUpHandler);
        ExecuteEvents.Execute(blushButton.gameObject, pointerEventData, ExecuteEvents.pointerClickHandler);
    }

    public void BlushButtonClicked()
    {
        if (buttonType != ButtonType.Blush)
        {
            book.LoadBlushes();
        }
        buttonType = ButtonType.Blush;
    }
    
    public void EyeShadowButtonClicked()
    {
        if (buttonType != ButtonType.EyeShadow)
        {
            book.LoadEyeShadows();
        }
        buttonType = ButtonType.EyeShadow;
    }
    
    public void LipstickButtonClicked()
    {
        if (buttonType != ButtonType.Lipstick)
        {
            book.LoadLipsticks();
        }
        buttonType = ButtonType.Lipstick;
    }
}
