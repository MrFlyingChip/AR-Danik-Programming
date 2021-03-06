﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class CellButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IPointerClickHandler
{

    public ButtonController buttonController;
    public int row;
    public int column;

    private float holdTime = 1f;

    public UnityEvent onLongPress = new UnityEvent();

    public bool activeCell = false;

    private bool animal = false;

    private bool crystal = false;

    private int animalNumber;
    private void Start()
    {
        onLongPress.AddListener(new UnityAction(DeleteAnimal));
    }

    public void DeleteAnimal()
    {
        if (animal)
        {
            GetComponent<Image>().sprite = buttonController.cellYes;
            buttonController.motherModeController.DeleteAnimal(row + "-" + column);
            buttonController.animalClicked = false;
            buttonController.animalsSprite[animalNumber].used = false;
            buttonController.animalsSprite[animalNumber].currentSprite = 0;
            animal = false;
        }
        else if (crystal)
        {
            GetComponent<Image>().sprite = buttonController.cellYes;
            buttonController.crystalClicked = false;
            buttonController.motherModeController.DeleteCrystal(row + "-" + column);
            crystal = false;
        }
    }

   

    public void OnPointerDown(PointerEventData eventData)
    {
        Invoke("OnLongPress", holdTime);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        CancelInvoke("OnLongPress");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CancelInvoke("OnLongPress");
    }

    private void OnLongPress()
    {
        onLongPress.Invoke();
    }

    float lastTimeClick;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (buttonController.animalClicked && activeCell && !crystal && !animal)
        {
            GetComponent<Image>().sprite = buttonController.animalsSprite[buttonController.currentAnimal].CurrentSprite();
            buttonController.motherModeController.SetNewAnimalArray(new Animal(row + "-" + column, buttonController.currentAnimal, 0));
            buttonController.animalClicked = false;
            buttonController.animalsSprite[buttonController.currentAnimal].used = true;
            animalNumber = buttonController.currentAnimal;
            animal = true;
        }
        else if (buttonController.crystalClicked && activeCell && !crystal && !animal)
        {
            GetComponent<Image>().sprite = buttonController.crystal;
            buttonController.crystalClicked = false;
            buttonController.motherModeController.SetNewCrystalArray(row + "-" + column);
            crystal = true;
        }
        else if (!activeCell && !buttonController.animalClicked && !buttonController.crystalClicked)
        {
            activeCell = true;
            buttonController.motherModeController.SetNewQuestArray(row + "-" + column);
            GetComponent<Image>().sprite = buttonController.cellYes;
        }
        else if (activeCell && !crystal && !animal)
        {
            float currentTimeClick = eventData.clickTime;
            if (Mathf.Abs(currentTimeClick - lastTimeClick) < 0.75f)
            {
                activeCell = false;
                buttonController.motherModeController.DeleteCell(row + "-" + column);
                GetComponent<Image>().sprite = buttonController.cellNo;
            }
            lastTimeClick = currentTimeClick;      
        }
        else if (animal)
        {
            GetComponent<Image>().sprite = buttonController.animalsSprite[animalNumber].RotatedSprite();
            buttonController.motherModeController.animalArray.Find(s => s.location == row + "-" + column).rotation = buttonController.animalsSprite[animalNumber].currentSprite;
        }
    }
}
