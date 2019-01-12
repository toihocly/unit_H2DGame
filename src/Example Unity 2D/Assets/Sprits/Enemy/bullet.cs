using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    // Use this for initialization
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject ImpactEffter;

    public AudioSource Fx;
    public AudioClip soundx;
    void Start () {
        rb.velocity = transform.right * speed;
	}
	
   void OnTriggerEnter2D(Collider2D hitinfo)
    {
        PlayerCheckHP player =  hitinfo.GetComponent<PlayerCheckHP>();
        if (player != null)
        {
            player.TakeDame(20);
        }
        if (hitinfo.tag != "Untagged" && hitinfo.tag !="Cherry" && hitinfo.tag != "Coin" )
        {
            Fx.PlayOneShot(soundx);
            Instantiate(ImpactEffter, transform.position, transform.rotation);
            Destroy(gameObject, 0.08f);
        }
    }


	
}
