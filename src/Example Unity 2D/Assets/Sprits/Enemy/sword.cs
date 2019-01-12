using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour {


    // Use this for initialization
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject ImpactEffter;

    public AudioSource Fx;
    public AudioClip soundx;
    //void Start()
    //{
    //    rb.velocity = transform.right * speed;
    //}

    void OnTriggerEnter2D(Collider2D hitinfo)
    {
        Debug.Log("ta dang chem vào ::" + hitinfo.gameObject.name);
        Enemy enemy = hitinfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDame(100);
        }
        //PlayerCheckHP player = hitinfo.GetComponent<PlayerCheckHP>();
        //if (player != null)
        //{
        //    player.TakeDame(20);
        //}
        //if (hitinfo.tag != "Untagged")
        //{

        //    Fx.PlayOneShot(soundx);
        //    Instantiate(ImpactEffter, transform.position, transform.rotation);
        //    //gameObject.SetActive(false);

        //    // Destroy(gameObject);
        //    Destroy(gameObject, 0.08f);
        //}
    }

}
