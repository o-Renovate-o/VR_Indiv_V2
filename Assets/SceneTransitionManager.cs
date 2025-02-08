using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public FadeScreen fadeScreen;
    public GameObject FaderScreen;

    public void GoToSceneAsync(int idLevel)
    {
        FaderScreen.SetActive(true);
        StartCoroutine(GoToSceneAsyncRoutine(idLevel));
    }
    IEnumerator GoToSceneAsyncRoutine(int sceneIndex)
    {
        FaderScreen.SetActive(true);
        fadeScreen.FadeOut();
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        float timer = 0;
        while (timer <= fadeScreen.fadeDuration && !operation.isDone)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        operation.allowSceneActivation = true;
    }
}
