using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    public static GameObject HowAmI;

    private Vector3 velocity = Vector3.zero;
    private float m_MovementSmoothing = .05f;
    

    public float moveForce = 20f;
    public float jumpForce = 300f;
    public AudioSource Fx;
    public AudioClip SoundJump;

    private Rigidbody2D myBody;
    private Animator animator;
    private float movement = 0f;

    private bool m_FacingRight = true;  // huong cua xe
    private bool grounded = true; // nếu nhân vật ở nển đất thì có thể nhảy lên
    private float h;
    private float v;


    // hiệu ứng chém
    public GameObject bulletPrefab;
    public Transform firePoint;
    void Start()
    {
        HowAmI = this.gameObject;
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
      
    }
    bool isStopActon = false;
    void Update()
    {
        h = Input.GetAxis("Horizontal"); // A or D // -1 0 1
        v = Input.GetAxis("Vertical");
        if (!isStopActon)
        {
            movement = h * moveForce ;


            PlayerAttack();
            PlayerRun();
            PlayerJump_Block();
        }

        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("Menu");
        }
           
    }

  

   

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0, 180f, 0);
    }

    void PlayerRun()
    {
        if (h != 0 && animator.GetBool("isJump")) // chạy + nhảy kết hợp
        {
            Debug.Log("tui dang nhay sao 1");
            Vector3 targetVelocity = new Vector2(movement , myBody.velocity.y);
            // And then smoothing it out and applying it to the character
            myBody.velocity = Vector3.SmoothDamp(myBody.velocity, targetVelocity, ref velocity, m_MovementSmoothing);
            animator.SetBool("isRun", true);
        }
        else
        if (h != 0 && !animator.GetBool("isJump")) // chạy 
        {
            Debug.Log("tui dang nhay sao 2");
            Vector3 targetVelocity = new Vector2(movement * 1.5f , myBody.velocity.y);
            // And then smoothing it out and applying it to the character
            myBody.velocity = Vector3.SmoothDamp(myBody.velocity, targetVelocity, ref velocity, m_MovementSmoothing);
            animator.SetBool("isRun", true);
        }
        else // đứng yên .. kết thục hoạt động chạy
        {
            Vector3 targetVelocity = new Vector2(0, myBody.velocity.y);
            myBody.velocity = Vector3.SmoothDamp(myBody.velocity, targetVelocity, ref velocity, m_MovementSmoothing);
            animator.SetBool("isRun", false);
        }
       
        
        if (h>0 && !m_FacingRight) // nv di chuyễn vể bên phải
        {
            Flip(); // xoay hướng nhân vật
        }
        else if (h < 0 && m_FacingRight) // nv di chuyễn vể bên trái
        {
            Flip(); // xoay hướng nhân vật
        }
    }


    private int numberOfJumps = 0;
    void PlayerJump_Block()
    {
       
        // block skill
        if (v < 0 )
        {
            animator.SetBool("isBlock", true);
        }
        //jump
        if ((v > 0 && numberOfJumps < 2 && Input.GetButtonDown("Vertical")) || (v > 0 && numberOfJumps < 2 && Input.GetKeyDown(KeyCode.X)))
        {
            Debug.Log("tui dang nhay sao 3");
            Fx.PlayOneShot(SoundJump);
            numberOfJumps++;
            animator.SetBool("isJump", true);
            myBody.AddForce( new Vector2(0f, jumpForce));
        }
       
        
        if (v == 0f)
        {
            animator.SetBool("isBlock", false);
        }
      
    }
    void OnCollisionEnter2D(Collision2D target)
    {
       
        if (target.gameObject.tag == "Grounded")
        {
            Debug.Log("isjump stop");
            animator.SetBool("isJump", false);
            animator.SetBool("isJump", false);
            numberOfJumps = 0;
            grounded = true;
            isStopActon = false;
        }
        else if (target.gameObject.tag == "Wall" && animator.GetBool("isJump"))
        {
            Debug.Log("stop action");
            isStopActon = true;
        }
    }
    private bool chekcAttack = false;
    void PlayerAttack()
    {
        //Debug.Log( "iput :: "  +Input.GetButtonDown("Fire1"));
        if (Input.GetButton("Fire1") && !chekcAttack)
        {
            // Instantiate(bulletPrefab, firePoint.transform.position + new Vector3(1.25f, -0.45f, 0.0f), firePoint.transform.rotation);
            animator.SetBool("isAttack", true);
            Instantiate(bulletPrefab, firePoint.transform.position , firePoint.transform.rotation);
            chekcAttack = true;
        }
        if (Input.GetButtonUp("Fire1") && chekcAttack)
        {
            animator.SetBool("isAttack", false);
            chekcAttack = false;
        }


    }
   
    
}
