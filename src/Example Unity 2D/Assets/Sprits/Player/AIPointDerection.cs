using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPointDerection : MonoBehaviour {

    // tạo ra AI để tiêu diệt địch
    GameObject ClosetsCoin;
    public float CombatRadius = 30f;
    private bool isFindCoin = false;
    private GameObject myPosition;
    private GameObject PointDerection;
    public SpriteRenderer ShowPointDerection;
    private Sprite mSpritePointDerection;
    void Awake()
    {
        myPosition = GameObject.FindGameObjectWithTag("Player");
        PointDerection = GameObject.Find("PointDerection");
        mSpritePointDerection = ShowPointDerection.sprite;
        ShowPointDerection.sprite = null;
       // PointDerection.SetActive(false);
    }
    // code thu nhặc được dưới idea của bản thân
    /*https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html*/
    public GameObject FindClosestCoin(Transform ThisMe)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Coin");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = ThisMe.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }



    // Update is called once per frame
    void Update()
    {
        if (!isFindCoin)
        {
            Debug.Log("Huy vi tri vàng mới");
            ClosetsCoin = FindClosestCoin(myPosition.transform);
            isFindCoin = true;
        }

        if (  !ClosetsCoin.activeSelf)
        {
            Debug.Log("Huy vi tri cu");
            isFindCoin = false;
        }
        //rotate to look at the player
        if (isFindCoin && Vector3.Distance(ClosetsCoin.transform.position, myPosition.transform.position) < CombatRadius)
        {
            if (mSpritePointDerection !=null)
            {
                ShowPointDerection.sprite = mSpritePointDerection;
            }
            

            transform.LookAt(ClosetsCoin.transform.position);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation
         
        }
        else
        {
            ShowPointDerection.sprite = null;
            isFindCoin = false;
        }

    }
}
