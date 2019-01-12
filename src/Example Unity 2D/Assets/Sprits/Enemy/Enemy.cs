using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject ImpactEffter;
    float hp = 20f;
    // Use this for initialization
    void Start () {
		
	}
    public void TakeDame(int dame)
    {
        hp -= 100;
        if (hp <= 0)
        {
            Destroy(gameObject);
            Instantiate(ImpactEffter, transform.position, transform.rotation);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
    
}
