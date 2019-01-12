using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

    public List<Button> buttons;
    public Sprite yellow_button, btn_boxCross;

    public GameObject lockedLevelText;

    int max_level;
    public GameObject loadingSence;
    public Slider slider;
    public Text txtProgress;
    #region LoadingSence
    public void LoadLevel(string senceName)
    {
        StartCoroutine(LoadAsynchronously(senceName));
    }

    IEnumerator LoadAsynchronously(string senceName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(senceName);
        loadingSence.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            //Debug.Log(operation.progress);
            txtProgress.text = string.Format("{0}", progress * 100);
            slider.value = progress;
            yield return null;

        }
    }
    #endregion

    void Start()
    {
        //max_level: man choi lon nhat nguoi choi da vuot qua (mac dinh bang 0)
        max_level = PlayerPrefs.GetInt("max_level");


        for (int i = 0; i <= max_level; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = string.Format("{0}", i + 1);
            buttons[i].GetComponent<Image>().sprite = yellow_button;
        }

        for (int i = max_level + 1; i < buttons.Count; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = "";
            buttons[i].GetComponent<Image>().sprite = btn_boxCross;
        }
    }
    public void goPlayGame(int level)
    {
        
        if (level <= max_level + 1)
        {
            lockedLevelText.SetActive(false);
            LoadLevel(string.Format("Level{0}", level));
        }
        else
        {
            lockedLevelText.SetActive(true);
        }
    }

   
}
