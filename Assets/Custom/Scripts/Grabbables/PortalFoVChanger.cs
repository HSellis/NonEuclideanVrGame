using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalFoVChanger : Grabbable
{
    public bool aspectRatio;

    private List<Camera> portalCameras = new List<Camera>();
    private float timerTick;
    private int multiplier = 1;


    // Start is called before the first frame update
    void Start()
    {
        timerTick = Time.time;
        foreach (GameObject portalCamObj in GameObject.FindGameObjectsWithTag("PortalCamera"))
        {
            portalCameras.Add(portalCamObj.GetComponent<Camera>());
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
