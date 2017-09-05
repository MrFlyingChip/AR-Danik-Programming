using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardButton : MonoBehaviour, IPointerClickHandler
{
    public UIController ui;

    float lastTimeClick;
    public void OnPointerClick(PointerEventData eventData)
    {
        float currentTimeClick = eventData.clickTime;
        if (Mathf.Abs(currentTimeClick - lastTimeClick) < 0.75f)
        {
           gameController.
        }
        else
        {
            ui.ChangeCardSprite(GetComponent<Image>());
        }
        lastTimeClick = currentTimeClick;


    }
}
