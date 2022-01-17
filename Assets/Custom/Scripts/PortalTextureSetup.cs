using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    public Camera camera1LeftEye;
    public Camera camera1RightEye;
    public Camera camera2LeftEye;
    public Camera camera2RightEye;

    public Material cameraMat1LeftEye;
    public Material cameraMat1RightEye;
    public Material cameraMat2LeftEye;
    public Material cameraMat2RightEye;

    // Start is called before the first frame update
    void Start()
    {
        if (camera1LeftEye.targetTexture != null)
        {
            camera1LeftEye.targetTexture.Release();
        }
        //camera1LeftEye.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        camera1LeftEye.targetTexture = new RenderTexture(2016, 2240, 24);
        cameraMat1LeftEye.mainTexture = camera1LeftEye.targetTexture;

        if (camera1RightEye.targetTexture != null)
        {
            camera1RightEye.targetTexture.Release();
        }
        camera1RightEye.targetTexture = new RenderTexture(2016, 2240, 24);
        cameraMat1RightEye.mainTexture = camera1RightEye.targetTexture;



        if (camera2LeftEye.targetTexture != null) {
            camera2LeftEye.targetTexture.Release();
        }
        //camera2LeftEye.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        camera2LeftEye.targetTexture = new RenderTexture(2016, 2240, 24);
        cameraMat2LeftEye.mainTexture = camera2LeftEye.targetTexture;

        if (camera2RightEye.targetTexture != null)
        {
            camera2RightEye.targetTexture.Release();
        }
        camera2RightEye.targetTexture = new RenderTexture(2016, 2240, 24);
        cameraMat2RightEye.mainTexture = camera2RightEye.targetTexture;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
