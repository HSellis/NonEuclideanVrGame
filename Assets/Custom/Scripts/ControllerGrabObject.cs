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
    private Vector3 grabPointOffset;


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
            Vector3 handToGrabbable = transform.position + grabPointOffset - grabbableInHand.transform.position;
            if (handToGrabbable.magnitude > 0.25)
            {
                //ReleaseObject();
            }
        }
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
        grabPointOffset = grabbableInHand.transform.position - transform.position;

        grabbableInHand.StartHolding(gameObject);
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
        grabbableInHand.StopHolding(gameObject);

        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            grabbableInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
            grabbableInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();

        }
        grabbableInHand = null;
        grabPointOffset = Vector3.zero;
    }
}
