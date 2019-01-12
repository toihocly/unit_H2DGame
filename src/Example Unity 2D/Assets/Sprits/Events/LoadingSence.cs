using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSence : MonoBehaviour {

    public GameObject loadingSence;
    public Slider slider;
    public Text txtProgress;
    public void LoadLevel(int senceIndex)
    {
        StartCoroutine(LoadAsynchronously(senceIndex));
    }

    IEnumerator LoadAsynchronously(int senceIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(senceIndex);
        loadingSence.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            txtProgress.text = string.Format("{0}%", progress * 100);
            slider.value = progress;
            yield return null;

        }
    }
}
