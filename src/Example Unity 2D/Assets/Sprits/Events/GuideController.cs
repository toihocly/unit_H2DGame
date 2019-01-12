using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideController : MonoBehaviour {


    public GameObject[] Guides;
    public BoxCollider2D[] PointGuides;

     void Start () {
		
	}
	
    void BtnOKE_OnClick(GameObject Dialog)
    {
        Time.timeScale = 1f;
        Dialog.SetActive(false);
    }



	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag =="Player")
        {
            Debug.Log(other.gameObject.name);
           
            if(PointGuides[0].enabled)
            {
                Time.timeScale = 0f;
                Guides[0].SetActive(true);
                Button Button = Guides[0].GetComponentInChildren<Button>();
                Button.onClick.AddListener(() => BtnOKE_OnClick(Guides[0]));
                PointGuides[0].enabled = false;
            }
            else if (PointGuides[1].enabled)
            {
                Time.timeScale = 0f;
                Guides[1].SetActive(true);
                Button Button = Guides[1].GetComponentInChildren<Button>();
                Button.onClick.AddListener(() => BtnOKE_OnClick(Guides[1]));
                PointGuides[1].enabled = false;
            }
            else if (PointGuides[2].enabled)
            {
                Time.timeScale = 0f;
                Guides[2].SetActive(true);
                Button Button = Guides[2].GetComponentInChildren<Button>();
                Button.onClick.AddListener(() => BtnOKE_OnClick(Guides[2]));
                PointGuides[2].enabled = false;
            }
            else if (PointGuides[3].enabled)
            {
                Time.timeScale = 0f;
                Guides[3].SetActive(true);
                Button Button = Guides[3].GetComponentInChildren<Button>();
                Button.onClick.AddListener(() => BtnOKE_OnClick(Guides[3]));
                PointGuides[3].enabled = false;
            }else if (PointGuides[4].enabled)
            {
                Time.timeScale = 0f;
                Guides[4].SetActive(true);
                Button Button = Guides[4].GetComponentInChildren<Button>();
                Button.onClick.AddListener(() => BtnOKE_OnClick(Guides[4]));
                PointGuides[4].enabled = false;
            }else if (PointGuides[5].enabled)
            {
                Time.timeScale = 0f;
                Guides[5].SetActive(true);
                Button Button = Guides[5].GetComponentInChildren<Button>();
                Button.onClick.AddListener(() => BtnOKE_OnClick(Guides[5]));
                PointGuides[5].enabled = false;
            }
            else if (PointGuides[6].enabled)
            {
                Time.timeScale = 0f;
                Guides[6].SetActive(true);
                Button Button = Guides[6].GetComponentInChildren<Button>();
                Button.onClick.AddListener(() => BtnOKE_OnClick(Guides[6]));
                PointGuides[6].enabled = false;
            }
        }
    }
}
