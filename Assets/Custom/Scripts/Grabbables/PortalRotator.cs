using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalRotator : Grabbable
{
    public Transform otherRoom;

    private float centerToHandAngleOffset;
    private float otherRoomAngleOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingHand)
        {
            float angle = calculateCenterToHandAngle() + centerToHandAngleOffset;
            transform.rotation = Quaternion.Euler(0, angle, 0);
            otherRoom.rotation = Quaternion.Euler(0, -angle, 0);
        }
    }

    public override void StartHolding(ControllerGrabObject hand)
    {
        holdingHand = hand;
        float centerToHandAngle = calculateCenterToHandAngle();
        centerToHandAngleOffset = transform.eulerAngles.y - centerToHandAngle;
        otherRoomAngleOffset = transform.eulerAngles.y - otherRoom.eulerAngles.y;
    }

    public override void StopHolding(ControllerGrabObject hand)
    {
        holdingHand = null;
        centerToHandAngleOffset = 0;
        otherRoomAngleOffset = 0;
    }

    private float calculateCenterToHandAngle()
    {
        Vector3 centerToHandNormalized = (holdingHand.transform.position - transform.position).normalized;
        float tanAngle = centerToHandNormalized.x / centerToHandNormalized.z;
        return Mathf.Atan(tanAngle) * Mathf.Rad2Deg;
    }
}
