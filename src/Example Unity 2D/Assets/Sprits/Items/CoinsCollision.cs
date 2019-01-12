using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollision : MonoBehaviour {

    // Use this for initialization
    private GameObject meter;

    public AudioSource Fx;
    public AudioClip Soundx;
	void Start () {
        meter = GameObject.Find("CoinsMaster");
    }
    bool isCheckColliderCoin = false;
	// Update is called once per frame
	void Update () {
       

        if (isCheckColliderCoin)
        {
            transform.position = Vector3.Lerp(transform.position, meter.transform.position, 0.05f);
         }
	}

    
    void OnTriggerEnter2D(Collider2D other)
    {
        // tien di chuyen ve lai man hinh game
        // tien cong them cho player
        if (!isCheckColliderCoin  && other.gameObject.tag =="Player")
        {
            isCheckColliderCoin = true;
            Fx.PlayOneShot(Soundx);
            CointAmount.coinAmount++;
            GameManagerment.tempScore++;
        }
        else if (other.gameObject.name == "CoinsMaster" && isCheckColliderCoin)
        {
            this.gameObject.SetActive(false);
        }
    }
}
