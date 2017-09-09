using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    

    public GameObject motherButton;
    public Sprite[] cardSprites;
    public Sprite nullCardSprite;
    public GameObject[] cards;
    public GameController gameController;

    private int currentCard;



    public void NoQuest()
    {

        motherButton.SetActive(true);
        motherButton.GetComponent<Animator>().SetBool("Ready", true);
    }

    public void RefreshCards(List<int> array)
    {
        foreach(GameObject go in cards)
        {
            go.GetComponent<Image>().sprite = nullCardSprite;
        }
        if (array != null)
        {
            for (int i = 0; i < array.Count; i++)
            {
                cards[i].GetComponent<Image>().sprite = cardSprites[array[i]];
            }
        }
    }

    public void ChangeCardSprite(Image image)
    {
        currentCard++;
        if (currentCard >= cardSprites.Length)
        {
            currentCard = 0;
        }
        image.sprite = cardSprites[currentCard];
    }

    public void RegisterCard()
    {
        gameController.RegisterCard(currentCard);
    }

    public void LoadScene(int scene)
    {
        StartCoroutine(SceneLoader.LoadSceneAsync(scene));
    }
}
