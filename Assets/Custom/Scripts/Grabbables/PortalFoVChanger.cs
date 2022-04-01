using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalFoVChanger : Grabbable
{
    public bool aspectRatio;

    private List<Camera> portalCameras = new List<Camera>();
    private float timerTick;
    private int multiplier = 1;

    public Camera mainCam;


    // Start is called before the first frame update
    void Start()
    {
        timerTick = Time.time;
        foreach (GameObject portalCamObj in GameObject.FindGameObjectsWithTag("PortalCamera"))
        {
            portalCameras.Add(portalCamObj.GetComponent<Camera>());
        }

        if (aspectRatio)
        {
            Matrix4x4 viewMatrix = mainCam.worldToCameraMatrix;
            //Matrix4x4 leftEyeMatrix = mainCam.GetStereoViewMatrix(Camera.StereoscopicEye.Left);
            //Matrix4x4 rightEyeMatrix = mainCam.GetStereoViewMatrix(Camera.StereoscopicEye.Right);
            //Debug.Log(leftEyeMatrix[12]);
            //Debug.Log(leftEyeMatrix[13]);
            //Debug.Log(leftEyeMatrix[14]);
            //Debug.Log(rightEyeMatrix);
            Debug.Log(viewMatrix);
            viewMatrix[12] += 0.01f;
            //mainCam.worldToCameraMatrix = viewMatrix;
            
            Debug.Log(mainCam.worldToCameraMatrix);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timerTick && holdingHand)
        {
            int i = 0;
            foreach (Camera portalCam in portalCameras)
            {
                
                if (aspectRatio)
                {

                    portalCam.aspect += 0.025f * multiplier;
                    if (i == 0) Debug.Log("aspect ratio: " + portalCam.aspect);
                }
                else
                {
                    portalCam.fieldOfView += 1 * multiplier;
                    if (i == 0) Debug.Log("Field of view: " + portalCam.fieldOfView);
                }
                

                i++;
            }
            timerTick = Time.time + 1;
        }
    }

    public override void StartHolding(ControllerGrabObject hand)
    {
        holdingHand = hand;
        if (holdingHand.transform.position.y > transform.position.y) multiplier = 1;
        else multiplier = -1;
    }

    public override void StopHolding(ControllerGrabObject hand)
    {
        holdingHand = null;
    }
}
