using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFollowCameraController : MonoBehaviour {

    // Use this for initialization
    public Canvas canvasUI;
    private Camera myCamera = null;
	void Start () {
        Debug.Log("kiemtra camera");
        GameObject a = GameObject.Find("Main Camera");
        myCamera = a.GetComponent<Camera>();
    }
    bool ischeckFolow = false;
	void Update () {
        
        
        if (myCamera != null && !ischeckFolow)
        {
            
            canvasUI.renderMode = RenderMode.ScreenSpaceCamera;
            canvasUI.worldCamera = myCamera;
            canvasUI.sortingLayerName = "Fontground";
        }
	}
}
