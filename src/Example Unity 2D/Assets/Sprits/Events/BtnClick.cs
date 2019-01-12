using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnClick : MonoBehaviour {

    public AudioSource myFx;
    public AudioClip ClickFx;
    public AudioClip HoverFx;
    // Use this for initialization

    public void HoverSound()
    {
        
            myFx.PlayOneShot(HoverFx);
        
        
    }  
    public void ClickSound()
    {
         
            myFx.PlayOneShot(ClickFx);
       
        
    }

}
