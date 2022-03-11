using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandle : Grabbable
{
    public DoorLock doorLock;
    //public bool rightHanded;

    private Rigidbody rb;
    private Vector3 grabPointRelativePos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingHand && (!doorLock || !doorLock.isLocked()))
        {
            Vector3 grabPointInWorldSpace = transform.TransformPoint(grabPointRelativePos);
            rb.velocity = (holdingHand.transform.position - grabPointInWorldSpace) * 20;
        }
    }

    public override void StartHolding(ControllerGrabObject hand)
    {
        holdingHand = hand;
        grabPointRelativePos = transform.InverseTransformPoint(hand.transform.position);

        //transform.Rotate(rightHanded ? 45 : -45, 0, 0);
    }

    public override void StopHolding(ControllerGrabObject hand)
    {
        holdingHand = null;

        //transform.Rotate(rightHanded ? -45 : 45, 0, 0);
    }

}
