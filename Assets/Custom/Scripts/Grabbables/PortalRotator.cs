using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalRotator : Grabbable
{
    public Transform otherRoom;
    public Transform rotatingPart;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingHand) rb.velocity = (holdingHand.transform.position - transform.position) * 30;

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
