using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class btnSelectPlayer : MonoBehaviour
{

    public Image ImagePlayer;
    public Sprite Image_Normal;
    public Sprite Image_After;
    public Image ImageButton;
    public Sprite Image2_Normal;
    public Sprite Image2_Hover;
    public Sprite Image2_Click;
    // Use this for initialization
    public AudioSource myFx;
    public AudioClip ClickFx;
    public AudioClip HoverFx;
    // Use this for initialization

   


   
    void Start()
    {
        if (ImagePlayer != null && ImagePlayer.name == PlayerGenerate.namePlayerWantGenarete)
        {
            btnClickPlayer();
        }
    }
    
 
    public void btnClickPlayer()
    {
        //LoadRest();
        if (PlayerGenerate.object1 != null)
        {
            PlayerGenerate.object1.sprite = PlayerGenerate.Normal1;
        }
        if (PlayerGenerate.object2 != null)
        {
            PlayerGenerate.object2.sprite = Image2_Normal;
        }

        Debug.Log("click me");
        if (ImagePlayer != null)
        {
            if (myFx.isPlaying)
            {
                myFx.Stop();
            }
            myFx.PlayOneShot(ClickFx);
            
            ImagePlayer.sprite = Image_After;
            PlayerGenerate.namePlayerWantGenarete = ImagePlayer.name;
            PlayerGenerate.object1 = ImagePlayer;
            PlayerGenerate.Normal1 = Image_Normal;

        }
        else
        {
            PlayerGenerate.namePlayerWantGenarete = "Random";
        }
        ImageButton.sprite = Image2_Click;
        PlayerGenerate.object2 = ImageButton;


    }
    public void btnHoverPlayer()
    {
        
        if (ImagePlayer != null && ImagePlayer.name != PlayerGenerate.namePlayerWantGenarete)
        {
            if (myFx.isPlaying)
            {
                myFx.Stop();
            }
            myFx.PlayOneShot(HoverFx);
            ImagePlayer.sprite = Image_After;
            ImageButton.sprite = Image2_Hover;
        }
       
    }
    public void btnRelaseePlayer()
    {
        if (ImagePlayer != null && ImagePlayer.name != PlayerGenerate.namePlayerWantGenarete)
        {
            if (ImagePlayer != null)
            {
                ImagePlayer.sprite = Image_Normal;
            }
            ImageButton.sprite = Image2_Normal;
        }

    }
}
