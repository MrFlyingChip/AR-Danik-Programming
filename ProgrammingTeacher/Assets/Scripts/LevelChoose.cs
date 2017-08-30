using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelChoose : MonoBehaviour, IPointerClickHandler
{

    public bool loadScene;
    public int scene;

    float lastTimeClick;
    public void OnPointerClick(PointerEventData eventData)
    {
      

        float currentTimeClick = eventData.clickTime;
        if (Mathf.Abs(currentTimeClick - lastTimeClick) < 0.75f)
        {
            StartCoroutine(SceneLoader.LoadSceneAsync(scene));
        }
        lastTimeClick = currentTimeClick;

        if (loadScene)
        {
            StartCoroutine(SceneLoader.LoadSceneAsync(scene));
        }
    }
}
