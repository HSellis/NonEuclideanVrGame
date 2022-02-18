using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandle : Grabbable
{
    public DoorLock doorLock;
    public bool rightHanded;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingHand && !doorLock.isLocked())
        {
            rb.velocity = (holdingHand.transform.position - transform.position) * 10;
        }
    }

    public override void StartHolding(ControllerGrabObject hand)
    {
        holdingHand = hand;

        //transform.Rotate(rightHanded ? 45 : -45, 0, 0);
    }

    public override void StopHolding(ControllerGrabObject hand)
    {
        holdingHand = null;

        //transform.Rotate(rightHanded ? -45 : 45, 0, 0);
    }

}
