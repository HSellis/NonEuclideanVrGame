using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR;

public class PortalCamera : MonoBehaviour
{
    public Transform duplicatedEye;
    public Transform portal;
    public Transform otherPortal;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eyeOffsetFromPortal = duplicatedEye.position - otherPortal.position;
        transform.position = portal.position + eyeOffsetFromPortal;

        float angularDiffBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        Quaternion portalRotationDifference = Quaternion.AngleAxis(angularDiffBetweenPortalRotations, Vector3.up);

        //Vector3 newCameraDirection = portalRotationDifference * duplicatedEye.forward;
        //transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);

        transform.rotation = duplicatedEye.rotation;
    }
}
