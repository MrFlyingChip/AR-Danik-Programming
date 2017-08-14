using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public class Language
{
    public Sprite languageSprite;
    public string URL;
    public string downloadString;
    public string printString;

    public void ChangeLanguage(int currentLanguage, Image languageImage, Text languageText)
    {
        PlayerPrefs.SetInt("Language", currentLanguage);
        languageImage.sprite = languageSprite;
        languageText.text = "1. " + downloadString + "\n" + "2. " + printString;
    }
}

public class MainMenuUI : MonoBehaviour
{

    public Language[] languages;
    public Image languageImage;
    public Text languageText;

    public GameObject playButton;
    public GameObject hand;

    private int currentLanguage = -1;
	// Use this for initialization
	void Start ()
    {
        LoadLanguage();

    }

    public void LinkToURL(string URL)
    {
        Application.OpenURL(URL);
    }

    private void LoadLanguage()
    {
        if (PlayerPrefs.HasKey("Language"))
        {
            currentLanguage = PlayerPrefs.GetInt("Language") - 1;
            ChangeLanguage();
        }
        else
        {
            ChangeLanguage();
        }
    }

    public void ChangeLanguage()
    {
        currentLanguage++;
        if (currentLanguage == languages.Length)
        {
            currentLanguage = 0;
        }
        languages[currentLanguage].ChangeLanguage(currentLanguage, languageImage, languageText);
    }

    public void LoadScene(int scene)
    {
        StartCoroutine(SceneLoader.LoadSceneAsync(scene));
    }

    public void Play()
    {
        playButton.GetComponent<Animator>().SetBool("Ready", false);
        hand.GetComponent<Animator>().SetBool("Ready", true);
    }

    public void OnPrintButtonClicked()
    {
        LinkToURL(languages[currentLanguage].URL);
    }
}
