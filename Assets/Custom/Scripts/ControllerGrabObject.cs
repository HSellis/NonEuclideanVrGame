using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerGrabObject : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;

    private Grabbable collidingGrabbable;
    private Grabbable grabbableInHand;
    private Vector3 grabPointRelativeToGrabbable;


    private void SetCollidingObject(Collider col)
    {
        Grabbable newGrabbable = col.GetComponent<Grabbable>();
        if (collidingGrabbable || newGrabbable == null)
        {
            return;
        }
        collidingGrabbable = newGrabbable;
    }

    // Update is called once per frame
    void Update()
    {
        if (grabAction.GetLastStateDown(handType))
        {
            if (collidingGrabbable)
            {
                GrabObject();
            }
        }

        if (grabAction.GetLastStateUp(handType))
        {
            if (grabbableInHand)
            {
                ReleaseObject();
            }
        }

        if (grabbableInHand)
        {
            Vector3 grabPointInWorldSpace = grabbableInHand.transform.TransformPoint(grabPointRelativeToGrabbable);
            Vector3 handOffsetFromGrabPoint = transform.position - grabPointInWorldSpace;

            if (handOffsetFromGrabPoint.magnitude > 0.15 && handOffsetFromGrabPoint.magnitude < 1)
            {
                ReleaseObject();
            }
        }
    }

    private void LateUpdate()
    {
        //if (grabbableInHand) handGrabbablePrevPos = grabbableInHand.transform.position;
    }

    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
        
    }

    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!collidingGrabbable)
        {
            return;
        }

        collidingGrabbable = null;
    }

    private void GrabObject()
    {
        grabbableInHand = collidingGrabbable;
        collidingGrabbable = null;
        grabPointRelativeToGrabbable = grabbableInHand.transform.InverseTransformPoint(transform.position);
        //handGrabbablePrevPos = grabbableInHand.transform.position;

        grabbableInHand.StartHolding(this);
        if (grabbableInHand.freelyMovable)
        {
            var joint = AddFixedJoint();
            joint.connectedBody = grabbableInHand.GetComponent<Rigidbody>();
        }
    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        grabbableInHand.StopHolding(this);

        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            Transform currentRoom = transform.parent.parent;
            Vector3 controllerVelocityInCurrentRoom = currentRoom.TransformVector(controllerPose.GetVelocity());
            grabbableInHand.GetComponent<Rigidbody>().velocity = controllerVelocityInCurrentRoom;
            grabbableInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();

        }
        grabbableInHand = null;
        grabPointRelativeToGrabbable = Vector3.zero;
        //handGrabbablePrevPos = Vector3.zero;
    }
}
