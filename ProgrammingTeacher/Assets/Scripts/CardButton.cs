using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class CardButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    public UIController ui;

    private float holdTime = 1f;
    public UnityEvent onLongPress = new UnityEvent();

    private void Start()
    {
        onLongPress.AddListener(new UnityAction(Click));
    }


    public void Click()
    {
        ui.RegisterCard();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Invoke("OnLongPress", holdTime);
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        CancelInvoke("OnLongPress");
        ui.ChangeCardSprite(GetComponent<Image>());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CancelInvoke("OnLongPress");
    }

    private void OnLongPress()
    {
        onLongPress.Invoke();
    }
}
