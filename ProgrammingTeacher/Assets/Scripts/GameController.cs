using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int questNumber;
    public UIController ui;
    public List<int> cardsArray = new List<int>();
    private bool canRegister;

    public int[] cardsArraySaved = new int[18];
    public int questTime;
    public string[] questArray;
    public string[] crystalArray;
    public string[] animalArray = new string[2];
    public int color = -1;

    void Start() {
        CheckForQuest();
    }

    private void CheckForQuest()
    {
        if (PlayerPrefs.HasKey("Quest" + questNumber))
        {
            canRegister = true;
            LoadLevel();
        }
        else
        {
            canRegister = false;
            ui.NoQuest();
        }
    }

    public void RegisterCard(int id)
    {
        cardsArray.Add(id);
        ui.RefreshCards(cardsArray);
    }

    public void DeleteCard()
    {
        if (cardsArray.Count > 0)
        {
            cardsArray.Remove(cardsArray[cardsArray.Count - 1]);
            ui.RefreshCards(cardsArray);
        }
    }

    private void LoadQuest()
    {

    }

	// Update is called once per frame
	void Update () {
		
	}
    public string[] quest;
    private void LoadLevel()
    {
        quest = PlayerPrefs.GetString("Quest" + questNumber).Split(';');
        cardsArraySaved = StringArrayToInt(quest[0].Split('+'));
        questArray = quest[1].Split('+');
        crystalArray = quest[2].Split('+');
        string[] animal = quest[3].Split('+');
        animalArray[0] = animal[0];
        animalArray[1] = animal[1];
        color = int.Parse(quest[4]);
        questTime = int.Parse(quest[5]);
    }

   private int[] StringArrayToInt(string[] str)
    {
        int[] intArray = new int[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            intArray[i] = int.Parse(str[i]);
        }
        return intArray;
    }

}
