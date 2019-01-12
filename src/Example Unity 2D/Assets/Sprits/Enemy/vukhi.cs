using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vukhi : MonoBehaviour {

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float CombatRadius = 30f;
    public AudioSource Fx;
    public AudioClip soundx;
    
    // Update is called once per frame
    //void Update () {
    //        shootLogic();
    //}

    public void StartFire(int numberOfBullets)
    {
        if (numberOfBullets < 0) return;
        switch (numberOfBullets)
        {
            case 1:
                shootLogic1();
                break;
            case 2:
                shootLogic2();
                break;
            default:
                shootLogic3();
                break;
        }
       
    }

    private float timer1 = 5f;
    void shootLogic1()
    {
        // shooting logic
        timer1 -= Time.deltaTime;
        if (timer1 <= 0)
        {
           
            Fx.PlayOneShot(soundx);
            // Spawn Bullet or whatever else
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            timer1 = 5f;
        }
      
    }
    private float timer2 = 3f;
    void shootLogic2()
    {
        // shooting logic
        timer2 -= Time.deltaTime;
        if (timer2 <= 0)
        {
            Fx.PlayOneShot(soundx);
            // Spawn Bullet or whatever else
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            timer2 = 3f;
        }

    }
    private float timer3 = 2f;
    void shootLogic3()
    {
        // shooting logic
        timer3 -= Time.deltaTime;
        if (timer3 <= 0)
        {

            Fx.PlayOneShot(soundx);
            // Spawn Bullet or whatever else
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            timer3 = 2f;
        }

    }

}
