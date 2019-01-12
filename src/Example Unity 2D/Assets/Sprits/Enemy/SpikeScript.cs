using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour {

    Vector3 pos;
    private PolygonCollider2D polygonCollider2D;
    GameObject[] gos;
    void Start () {
        pos = transform.position;
        polygonCollider2D = this.gameObject.GetComponent<PolygonCollider2D>();
        
       
    }
    //public Transform target;//set target from inspector instead of looking in Update
    public float speed = 3f;

    void Update()
    {
        //rotate to look at the player
        transform.LookAt(gos[0].transform.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation


        //move towards the player
        //if (Vector3.Distance(transform.position, gos[0].transform.position) > 1f)
        //{//move if distance from target is greater than 1
        //    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        //}
    }

        void OnCollisionEnter2D(Collision2D collision)
        {
            StartCoroutine(RespawnAfter(10.0f));
      
        }

    IEnumerator RespawnAfter(float time)
    {
        yield return new WaitForSeconds(time);
        transform.position = pos;
    }

  
}
