using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherModeController : MonoBehaviour {

    public int questNumber;

    public int[] cardsArray = new int[18];
    public int questTime = 120;
    public int[,] questArray = new int[10, 19];

    public void SetNewCard(int number)
    {
        cardsArray[number] = (cardsArray[number] == 0) ? 1 : 0; 
    }

    public bool SetNewQuestTime(string timeInput)
    {
        return int.TryParse(timeInput, out questTime);
    }

    public void LoadScene(int scene)
    {
        StartCoroutine(SceneLoader.LoadSceneAsync(scene));
    }

    public void SetNewQuestArray(int row, int column)
    {
        questArray[row, column] = (questArray[row, column] == 0) ? 1 : 0;
    }

    public void Save()
    {

    }
}
