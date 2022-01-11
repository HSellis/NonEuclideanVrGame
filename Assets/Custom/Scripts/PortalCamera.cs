using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR;

public class PortalCamera : MonoBehaviour
{
    public Transform duplicatedEye;
    public Transform portal;
    public Transform otherPortal;

    //public List<XRNodeState> nodeStates;
    //private XRNodeState single_xrnode;

    //private Vector3 left_eye_pos, right_eye_pos;
    //private Quaternion left_eye_rot, right_eye_rot;

    // Start is called before the first frame update
    void Start()
    {
        //nodeStates = new List<XRNodeState>();

        // Add left eye node to the nodeStates list, which will be represented by nodeStates[0]
        //single_xrnode.nodeType = XRNode.LeftEye;
        //nodeStates.Add(single_xrnode);

        // Add right eye node to the nodeStates list, which will be represented by nodeStates[1]
        //single_xrnode.nodeType = XRNode.RightEye;
        //nodeStates.Add(single_xrnode);
    }

    // Update is called once per frame
    void Update()
    {
        //InputTracking.GetNodeStates(nodeStates);

        // Try to get the parameters and place them into the correct variables
        //nodeStates[0].TryGetPosition(out left_eye_pos);

        //nodeStates[1].TryGetPosition(out right_eye_pos);



        //Vector3 eyeOffsetFromPortal = duplicatedEye.position - otherPortal.position;
        Vector3 eyeOffsetFromPortal = duplicatedEye.position - otherPortal.position;
        transform.position = portal.position + eyeOffsetFromPortal;

        float angularDiffBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        Quaternion portalRotationDifference = Quaternion.AngleAxis(angularDiffBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationDifference * duplicatedEye.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);

    }
}
