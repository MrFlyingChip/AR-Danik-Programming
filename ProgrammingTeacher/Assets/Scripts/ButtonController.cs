using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class AnimalSprite
{
    public Sprite[] animalsSprite;
    public int currentSprite;
    public bool used;

    public Sprite CurrentSprite()
    {
        return animalsSprite[currentSprite];
    }

    public Sprite RotatedSprite()
    {
        if (currentSprite < animalsSprite.Length - 1)
        {
            currentSprite++;
        }
        else
        {
            currentSprite = 0;
        }
        return animalsSprite[currentSprite];
    }
}


public class ButtonController : MonoBehaviour {

    public Sprite[] questCardSprites;

    public GameObject timeInput;
    public MotherModeController motherModeController;

    public AnimalSprite[] animalsSprite;
    public int currentAnimal = -1;

    public Sprite[] colorSprites;

    public bool animalClicked;
    public bool crystalClicked;

    public Sprite crystal;
    public Sprite cellYes;
    public Sprite cellNo;

    public Sprite cellNoClear;
    public void Start()
    {
        timeInput.GetComponent<InputField>().text = motherModeController.questTime.ToString();
    }

    public void OnQuestCardClick(GameObject go)
    {
        int number = int.Parse(go.name) - 1;
        motherModeController.SetNewCard(number);
        go.GetComponent<Image>().sprite = questCardSprites[motherModeController.cardsArray[number]];
    }

    public void OnColorClick(int color)
    {
        CellButton[] cells = FindObjectsOfType<CellButton>();
        foreach(CellButton c in cells)
        {
            if (!c.activeCell)
            {
                c.GetComponent<Image>().sprite = colorSprites[color];
            }
            
        }
        cellNo = colorSprites[color];
        motherModeController.color = color;
    }

    public void OnQuestTimeChanged()
    {
        string timeString = timeInput.GetComponent<InputField>().text;
        if (!motherModeController.SetNewQuestTime(timeString))
        {
            motherModeController.SetNewQuestTime("120");
            timeInput.GetComponent<InputField>().text = motherModeController.questTime.ToString();       
        }
        else if (int.Parse(timeString) > 999)
        {
            motherModeController.SetNewQuestTime("999");
            timeInput.GetComponent<InputField>().text = motherModeController.questTime.ToString();
        }
        else
        {
            motherModeController.SetNewQuestTime(timeString);
        }
    }

    public void OnClockButtonClick()
    {
        timeInput.SetActive(!timeInput.active);
    }

    public void OnAnimalClicked(int animal)
    {
        if (motherModeController.animalArray.Count <= 1 && !animalsSprite[animal].used)
        {
            animalClicked = true;
            currentAnimal = animal;
        }      
    }   

    public void OnCrystalButtonClicked()
    {
        crystalClicked = !crystalClicked;
    }

}
