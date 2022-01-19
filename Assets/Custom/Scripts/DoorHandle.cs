using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandle : Grabbable
{
    private GameObject holdingHand;
    private Vector3 offsetFromHoldingHand;

    public Transform door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingHand)
        {
            Vector3 doorToHandNormalized = (holdingHand.transform.position - door.transform.position).normalized;
            door.rotation = Quaternion.LookRotation(doorToHandNormalized, Vector3.left);
        }
    }

    public override void StartHolding(GameObject hand)
    {
        holdingHand = hand;
        

        transform.Rotate(-45, 0, 0);
    }

    public override void StopHolding(GameObject hand)
    {
        holdingHand = null;
        offsetFromHoldingHand = Vector3.zero;

        transform.Rotate(45, 0, 0);
    }
}
