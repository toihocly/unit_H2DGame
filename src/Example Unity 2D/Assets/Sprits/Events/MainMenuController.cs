using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {
    
    

    Scene m_cur_Scene;
    void Awake()
    {
        m_cur_Scene = SceneManager.GetActiveScene();
        //name = m_cur_Scene.name;
       
    }
	public void  goMenuGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelMenu");
        //LoadLevel("LevelMenu");
    }
    public void goOptionGame()
    {
        SceneManager.LoadScene("Menu_Option");
        //LoadLevel("Menu_Option");
    }
    public void goQuitGame()
    {
        Application.Quit();
    }

    public void goHeroGame()
    {
        SceneManager.LoadScene("Menu_Hero");
        //LoadLevel("Menu_Hero");
    }
    public void goHelpGame()
    {
        SceneManager.LoadScene("Menu_Help");
        //LoadLevel("Menu_Help");
    }
    public void goBackGame()
    {
        switch (m_cur_Scene.name)
        {
            case "LevelMenu":
                SceneManager.LoadScene("Menu");
                break;
            case "Menu_Option":
                SceneManager.LoadScene("Menu");
                break;
            case "Menu_Hero":
                SceneManager.LoadScene("Menu_Option");
                
                break;
            case "Menu_Help":
                SceneManager.LoadScene("Menu_Option");
               
                break;
            default:
                break;
        }
    }

    void BtnYes_Onclick(GameObject Dialog)
    {
        PlayerPrefs.SetInt("max_level", 0);
        Dialog.SetActive(false);
        Time.timeScale = 1f;
    }
    void BtnNo_Onclick(GameObject Dialog)
    {
        Dialog.SetActive(false);
        Time.timeScale = 1f;
    }


    public void UnlockToTheVersion(GameObject Dialog)
    {
        Dialog.SetActive(true);
        Time.timeScale = 0f;
        Button[] Button = Dialog.GetComponentsInChildren<Button>();
        Button[0].onClick.AddListener(()=>BtnYes_Onclick(Dialog));
        Button[1].onClick.AddListener(()=>BtnNo_Onclick(Dialog));
        
    }

    public void Rest()
    {
        CointAmount.coinAmount = 0;
        SceneManager.LoadScene(m_cur_Scene.name);
        //LoadLevel(m_cur_Scene.name);
        Time.timeScale = 1f;

    }

}
