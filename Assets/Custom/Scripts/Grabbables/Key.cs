using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Grabbable
{
    public DoorLock doorLock;
    public bool isNecessaryScale = false;
    public float necessaryScale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isNecessaryScale && transform.localScale.x != necessaryScale) return;

        Vector3 toLock = doorLock.transform.position - transform.position;
        if (toLock.magnitude <= 0.1)
        {
            doorLock.Activate();
        }
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
