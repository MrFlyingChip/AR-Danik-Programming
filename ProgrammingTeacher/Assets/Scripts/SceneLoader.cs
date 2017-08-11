using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{

    public static IEnumerator LoadSceneAsync(int scene)
    {
        #if UNITY_PRO_LICENSE
		AsyncOperation async = SceneManager.LoadSceneAsync(scene);
		while (!async.isDone)
		{
			yield return 0;
		}
        #else
			SceneManager.LoadScene (scene);
			yield return 0;
        #endif
    }

}
