using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalRotator : Grabbable
{
    public Transform otherRoom;
    public Transform rotatingPart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotatorEulerAngles = rotatingPart.rotation.eulerAngles;
        otherRoom.rotation = Quaternion.Euler(rotatorEulerAngles.x, -rotatorEulerAngles.y, rotatorEulerAngles.z);
    }

    public override void StartHolding(ControllerGrabObject hand)
    {
        holdingHand = hand;
    }

    public override void StopHolding(ControllerGrabObject hand)
    {
        holdingHand = null;
    }

}
