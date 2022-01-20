using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovingPipe : Grabbable
{
    private GameObject holdingHand;
    private Vector3 offsetFromHoldingHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingHand)
        {
            float newY = (holdingHand.transform.position + offsetFromHoldingHand).y;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            
        }
    }

    public override void StartHolding(GameObject hand)
    {
        holdingHand = hand;
        offsetFromHoldingHand = transform.position - hand.transform.position;
    }

    public override void StopHolding(GameObject hand)
    {
        holdingHand = null;
        offsetFromHoldingHand = Vector3.zero;
    }
}
