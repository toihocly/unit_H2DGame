using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCheckHP : MonoBehaviour {

    float hp = 1000f;
    Slider HPSlider;

    private GameObject GameOverPanel ;
    void Awake()
    {
        GameOverPanel = GameObject.Find("Canvas/GameOver");
        GameOverPanel.SetActive(false);
    }

    void Start () {
        HPSlider = GameObject.FindGameObjectWithTag("HPSlider").GetComponent<Slider>();
        HPSlider.maxValue = hp;
        HPSlider.minValue = 0f;
        HPSlider.value = hp;
	}

    void Update()
    {
        HPSlider.value = hp;
       
    }

    public void TakeDame(int dame)
    {
        hp -= 100;
        if (hp <= 0)
        {
            Die();
        }
    }

    public void Addblood(int blood)
    {
        hp += blood;
        if (hp >1000)
        {
            hp = 1000;
        }
    }
    public void Die()
    {
        hp = 0;
       // Debug.Log("Player Die");
        GameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }


   
    void   OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Death")
        {
            Die();
        }

        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cherry")
        {
            Debug.Log(" ta dang cham vao  ai vay 1  : " + other.gameObject.tag);
            Destroy(other.gameObject);
            Addblood( 300);
        }
        Debug.Log(" ta dang cham vao  ai vay 2 : "+ other.gameObject.tag);
    }
}
