using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandle : Grabbable
{
    private GameObject holdingHand;
    private float doorToHandAngleOffset;

    public Transform door;
    public DoorLock doorLock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingHand && !doorLock.isLocked)
        {
            float doorAngle = calculateDoorToHandAngle() + doorToHandAngleOffset;
            door.rotation = Quaternion.Euler(0, doorAngle, 0);
        }
    }

    public override void StartHolding(GameObject hand)
    {
        holdingHand = hand;
        float doorToHandAngle = calculateDoorToHandAngle();
        doorToHandAngleOffset = door.eulerAngles.y - doorToHandAngle;

        transform.Rotate(-45, 0, 0);
    }

    public override void StopHolding(GameObject hand)
    {
        holdingHand = null;
        doorToHandAngleOffset = 0;

        transform.Rotate(45, 0, 0);
    }

    private float calculateDoorToHandAngle()
    {
        Vector3 doorToHandNormalized = (holdingHand.transform.position - door.position).normalized;
        float tanAngle = doorToHandNormalized.x / doorToHandNormalized.z;
        return Mathf.Atan(tanAngle) * Mathf.Rad2Deg;
    }

}
