using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    public GameObject nextAnimationGameObject;

    public void LoadScene(int scene)
    {
        StartCoroutine(SceneLoader.LoadSceneAsync(scene));
    }

    public void StartNextAnimation()
    {
        nextAnimationGameObject.GetComponent<Animator>().SetBool("Ready", true);
    }
}
