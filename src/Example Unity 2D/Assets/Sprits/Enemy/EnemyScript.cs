using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public GameObject bullet;

    Animator animator;
    const int IDLE = 0;
    const int ATTACK = 1;
    const int RUN = 2;
    const int DIE = 3;
    const string ENEMYANIMSTATE = "EnemyAnimState";

    AudioSource audioSource;

    public float attack_duration = 0.6f;
    IEnumerator attackCoroutine = null;

    float x;

    public float hp = 1000f;
    public float damage = 100f;

    void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        x = transform.position.x;
    }


    void FixedUpdate()
    {
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

        Vector3 pos = transform.position;
        pos.x = x;
        transform.position = pos;

        CheckAlive();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "HeroBullet")
        {
            Destroy(collision);
            hp -= 500;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Player")
        {
            StartAttack();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Player")
        {
            StopAttack();
        }
    }


    IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(attack_duration);
        Vector3 pos = transform.position;
        //float scaleX = transform.localScale.x;

        GameObject bulletInstance = Instantiate(bullet, pos, Quaternion.identity);
        bulletInstance.tag = "EnemyBullet";
       // bulletInstance.GetComponent<BulletScript>().scaleX = scaleX;

        if (attackCoroutine != null)
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    public void StartAttack()
    {
        animator.SetInteger(ENEMYANIMSTATE, ATTACK);
        audioSource.Play();

        attackCoroutine = AttackCoroutine();
        StartCoroutine(attackCoroutine);
    }

    public void StopAttack()
    {
        animator.SetInteger(ENEMYANIMSTATE, IDLE);
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
        }
        attackCoroutine = null;
    }

    void CheckAlive()
    {
        if (hp <= 0)
        {
            animator.SetInteger(ENEMYANIMSTATE, DIE);
            Destroy(gameObject, 3f);
            Destroy(this);
            audioSource.Stop();
        }
    }
}
