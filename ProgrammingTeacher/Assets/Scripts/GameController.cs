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
    public List<string> questArray = new List<string>();
    public List<string> crystalArray = new List<string>();
    public List<Animal> animalArray = new List<Animal>();
    public int color = -1;

    void Start() {
        CheckForQuest();
    }

    private void CheckForQuest()
    {
        if (PlayerPrefs.HasKey("Quest" + questNumber))
        {
            canRegister = true;
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
        if (cardsArray != null)
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
}
