using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Animal
{
    public string location;
    int number;
    public int rotation;

    public Animal(string location, int number, int rotation)
    {
        this.location = location;
        this.number = number;
        this.rotation = rotation;
    }

    public string SaveString()
    {
        return location + "/" + number + "/" + rotation;
    }
}

public class MotherModeController : MonoBehaviour {

    public int questNumber;

    public int[] cardsArray = new int[18];
    public int questTime = 120;
    public List<string> questArray = new List<string>();
    public List<string> crystalArray = new List<string>();
    public List<Animal> animalArray = new List<Animal>();
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

    public void SetNewAnimalArray(Animal animal)
    {
        animalArray.Add(animal);
    }

    public void DeleteAnimal(string location)
    {
        Animal a = animalArray.Find(s => s.location == location);
        animalArray.Remove(a);
    }

    public void Save()
    {
        string s = WriteArray(cardsArray);
        if (questArray.Count > 0) s += ";" + WriteList(questArray);
        if (crystalArray.Count > 0) s += ";" + WriteList(crystalArray);
        s += ";" + animalArray[0].SaveString() + "+" + animalArray[1].SaveString();
        PlayerPrefs.SetString("Quest" + questNumber, s);
    }

    private string WriteArray(int[] array)
    {
        string s = array[0].ToString();
        for (int i = 1; i < array.Length; i++)
        {
            s += "+" + array[i];
        }
        return s;
    }

    private string WriteList(List<string> list)
    {
        string s = list[0];  
        for (int i = 1; i < list.Count; i++)
        {
            s += "+" + list[i];
        }
        return s;
    }
}
