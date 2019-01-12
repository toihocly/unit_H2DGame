using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoAhead1 : MonoBehaviour {

    private Rigidbody2D myBody;
    public float speed = 2f;
    // Use this for initialization
    void Start () {
        myBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    bool vacham = false;
    int solanvacham = 0;
    float timer = 5f;
    void Update () {
        if (!vacham)
        {
            myBody.velocity = transform.right * speed;
           // vacham = true;
        }
           
        else if (vacham && solanvacham < 1)
        {
            solanvacham++;
            myBody.velocity = -transform.right * 2;
        }

        if (solanvacham == 1)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                vacham = false;
                solanvacham = 0;
                timer = 5;
            }
        }
            

    }
    
    void    OnCollisionEnter2D( Collision2D other)
    {
        //collider.isTrigger = false;
        if (other.gameObject.tag =="Player")
        {
            PlayerCheckHP player = other.gameObject.GetComponent<PlayerCheckHP>();
            player.TakeDame(100);
            Flip();
            // collider.isTrigger = true;
            vacham = true;


        }

        if (other.gameObject.tag == "Wall")
        {
            Flip();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.gameObject.tag != "Player")
        {
            myBody.velocity = transform.up * speed;
            StartCoroutine(WaitEnemyRest(5));
        }
    }

    IEnumerator WaitEnemyRest(float time)
    {
        yield return new WaitForSeconds(time);
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
       // m_FacingRight = !m_FacingRight;

        transform.Rotate(0, 180f, 0);
    }
}
