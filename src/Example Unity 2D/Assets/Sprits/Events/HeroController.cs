using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeroController : MonoBehaviour {

    public List<Button> buttons;

    //public GameObject lockedHeroText;

    int max_level;


    void Start()
    {
        //max_level: man choi lon nhat nguoi choi da vuot qua (mac dinh bang 0)
        max_level = PlayerPrefs.GetInt("max_level");
        Debug.Log("TÔI ĐÃ VÀO ĐÂY RỒI MÀ :: " +max_level );
        
        switch (max_level)
        {
            case 2:
            case 3:
            case 4:
                buttons[0].gameObject.SetActive(true);
                break;
            case 5:
            case 6:
                buttons[0].gameObject.SetActive(true);
                buttons[1].gameObject.SetActive(true);
                break;
            case 7:
            case 8:
            case 9:
                buttons[0].gameObject.SetActive(true);
                buttons[1].gameObject.SetActive(true);
                buttons[2].gameObject.SetActive(true);
                break;
            case 10:
            case 11:
            case 12:
                buttons[0].gameObject.SetActive(true);
                buttons[1].gameObject.SetActive(true);
                buttons[2].gameObject.SetActive(true);
                buttons[3].gameObject.SetActive(true);
                break;
        }


    }
  
}
