using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Grabbable
{
    public DoorLock doorLock;
    public bool isNecessaryScale = false;
    public float necessaryScale;

    private Vector3 origPos;

    // Start is called before the first frame update
    void Start()
    {
        origPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isNecessaryScale && transform.localScale.x != necessaryScale) return;

        Vector3 toLock = doorLock.transform.position - transform.position;
        if (toLock.magnitude <= 0.05)
        {
            doorLock.Activate();
        }

        if (transform.position.y < -200)
        {
            transform.position = origPos + new Vector3(0, 0.1f, 0);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
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
