using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

    public Sprite[] questCardSprites;

    public GameObject timeInput;
    public MotherModeController motherModeController;

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

    public void OnQuestTimeChanged()
    {
        string timeString = timeInput.GetComponent<InputField>().text;
        if (!motherModeController.SetNewQuestTime(timeString))
        {
            motherModeController.SetNewQuestTime("120");
            timeInput.GetComponent<InputField>().text = motherModeController.questTime.ToString();       
        }
        else if (int.Parse(timeString) < 1 || int.Parse(timeString) > 999)
        {
            motherModeController.SetNewQuestTime("120");
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

}
