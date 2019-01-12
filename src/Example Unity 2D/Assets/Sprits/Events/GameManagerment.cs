using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerment : MonoBehaviour {

    //LoadingSence
    public GameObject loadingSence;
    public Slider slider;
    public Text txtProgress;




    // Use this for initialization
    Scene m_pre_Scene ;
    Scene m_cur_Scene;
    public static int tempScore = 0;
    private Animator animator;
    // mặc định số tiền cần phải lụm nếu mua qua màn tiếp theo
    // nhìn theo list ở dưới muốn qua level 1. người chơi phải ăn đủ 12 coin
    List<int> scores = new List<int> { 12, 12, 22, 21, 25, 27, 30, 33, 36, 39, 42, 45 };
    // Update is called once per frame
    int mapIndex = -1;
   // MainMenuController _MenuController = null;
    void Awake()
    {
        //_MenuController = new MainMenuController();
    }



    void Start () {
        animator = GetComponent<Animator>();
        m_cur_Scene = SceneManager.GetActiveScene();
        if (!m_pre_Scene.IsValid() || m_cur_Scene != m_pre_Scene)
        {
            tempScore = 0;
            m_pre_Scene = m_cur_Scene;
        }
       // Debug.Log("log scene : " + m_cur_Scene.name);
       // Debug.Log("log scene pre : " + m_pre_Scene.name);
    }
    
	void Update () {
        mapIndex = Convert.ToInt32(m_cur_Scene.name.Substring(5)) - 1;
        if (tempScore == scores[mapIndex])
        {
            animator.SetBool("isUnLock", true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && animator.GetBool("isUnLock"))
        {
            if (mapIndex < 11)
            {
                //SceneManager.LoadScene(string.Format("Level{0}", mapIndex + 2));
                //_MenuController.goPlayGame(string.Format("Level{0}", mapIndex + 2));
                LoadLevel(string.Format("Level{0}", mapIndex + 2));
                UnlockToTheVersion(mapIndex + 1);
            }
            else if (mapIndex == 11)
            {
                UnlockToTheVersion(12);
                SceneManager.LoadScene("EndGame");
                //_MenuController.goPlayGame("EndGame");
            }
            


        }
    }
    public void UnlockToTheVersion(int mapIndex)
    {
        PlayerPrefs.SetInt("max_level", mapIndex);
    }

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
}
