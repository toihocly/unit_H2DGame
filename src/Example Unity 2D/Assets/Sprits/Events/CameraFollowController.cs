using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour {

    public Cinemachine.CinemachineVirtualCamera Camera;
    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    bool ischeckfollow = false;
    void Update()
    {
        if (PlayerMovement.HowAmI != null & !ischeckfollow)
        {
            // update money
            Camera.Follow = PlayerMovement.HowAmI.transform;
            ischeckfollow = true;
        }
       
    }
}
