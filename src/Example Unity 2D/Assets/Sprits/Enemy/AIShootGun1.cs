using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShootGun1 : MonoBehaviour {

    // tạo ra AI để tiêu diệt địch
    GameObject[] gos;
    public float CombatRadius = 30f;
    public int NumberOfBullets = 1;
    private vukhi TypeAttack;
    private bool isFindPlayer = false;
    public GameObject WeaponPoint; 
    void Start () {
        if (WeaponPoint != null)
        {
            TypeAttack = WeaponPoint.GetComponent<vukhi>();
        }
    
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        if (!isFindPlayer)
        {
            gos = GameObject.FindGameObjectsWithTag("Player");
            isFindPlayer = true;
        }

        //rotate to look at the player
        if (isFindPlayer && Vector3.Distance(gos[0].transform.position, this.transform.position) < CombatRadius)
        {
            transform.LookAt(gos[0].transform.position);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation
            if (TypeAttack != null)
            {
                TypeAttack.StartFire(NumberOfBullets);
            }
        }

    }
}
