using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoOnGround : MonoBehaviour {

    public Transform startPos, endPos;
    private bool collision;
    public float speed = 1f;
    private Rigidbody2D myBody;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
        ChangeDirction();

    }
    void Move()
    {
            myBody.velocity = transform.right * speed;
      
      
    }
    void ChangeDirction ()
    {
        collision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("Grounded"));
        Debug.DrawLine(startPos.position, endPos.position,Color.green);
        if (!collision)
        {
            transform.Rotate(0, 180f, 0);
        }
    }

    void OnCollisionEnter2D( Collision2D other)
    {
        if (other.gameObject.tag  == "Player")
        {
            PlayerCheckHP player = other.gameObject.GetComponent<PlayerCheckHP>();
            transform.Rotate(0, 180f, 0);
            player.TakeDame(150);
        }
        else if (other.gameObject.tag == "Wall")
        {
            transform.Rotate(0, 180f, 0);
        }
    }
}
