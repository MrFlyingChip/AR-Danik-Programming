using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherModeController : MonoBehaviour {

    public int questNumber;

    public int[] cardsArray = new int[18];
    public int questTime = 120;
    public List<string> questArray = new List<string>();
    public List<string> crystalArray = new List<string>();
    public List<string> animalArray = new List<string>();
    public int color = -1;

    public void SetNewCard(int number)
    {
        if (cardsArray[number] < 10)
        {
            cardsArray[number]++;
        }
        else
        {
            cardsArray[number] = 0;
        }
    }

    public bool SetNewQuestTime(string timeInput)
    {
        return int.TryParse(timeInput, out questTime);
    }

    public void LoadScene(int scene)
    {
        StartCoroutine(SceneLoader.LoadSceneAsync(scene));
    }

    public void SetNewQuestArray(string cell)
    {
        questArray.Add(cell);
    }

    public void DeleteCell(string cell)
    {
        questArray.Remove(cell);
    }

    public void SetNewCrystalArray(string cell)
    {
        crystalArray.Add(cell);
    }

    public void DeleteCrystal(string cell)
    {
        crystalArray.Remove(cell);
    }

    public void SetNewAnimalArray(string cell)
    {
        animalArray.Add(cell);
    }

    public void DeleteAnimal(string cell)
    {
        animalArray.Remove(cell);
    }

    public void Save()
    {
        Debug.Log("Save");
    }
}
