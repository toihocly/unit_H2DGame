using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AISound : MonoBehaviour {

    Scene m_per_Scene ;
    Scene m_cur_Scene;
    public AudioSource Fx;
    public AudioClip StartSound;
    public AudioClip PlayingSound;
    public AudioClip EndSound;


    void ChangeMusic(string NameScene)
    {
        switch (m_cur_Scene.name)
        {
            case "Menu":
            case "Menu_Option":
            case "LevelMenu":
            case "Menu_Help":
                if (Fx.clip != StartSound || !Fx.isPlaying)
                {
                    Fx.clip = StartSound;
                    Fx.Play();
                }
                break;
            case "Menu_Hero":
                Fx.Stop();
                break;
            case "Level1":
            case "Level2":
            case "Level3":
            case "Level4":
            case "Level5":
            case "Level6":
            case "Level7":
            case "Level8":
            case "Level9":
            case "Level10":
            case "Level11":
            case "Level12":
                if (Fx.clip != PlayingSound)
                {
                    Fx.clip = PlayingSound;
                    Fx.Play();
                }
                break;
            case "EndGame":
                if (Fx.clip != EndSound)
                {
                    Fx.clip = EndSound;
                    Fx.Play();
                }
                break;
            default:
                break;
        }
    }
    void Start()
    {
        m_cur_Scene = SceneManager.GetActiveScene();
    }

    void Update () {
        m_cur_Scene = SceneManager.GetActiveScene();
        if (m_cur_Scene != m_per_Scene)
        {
            Debug.Log("Update Mussic");
            m_per_Scene = m_cur_Scene;
            ChangeMusic(m_per_Scene.name);
        }
       
    }
	
	
}
