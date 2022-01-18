using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR;

public class PortalCamera : MonoBehaviour
{
    private new Camera camera;
    public Material cameraTextureMat;

    public Transform duplicatedEye;
    
    //public Transform portal;
    //public Transform otherPortal;
    public Transform thisRoom;
    public Transform otherRoom;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        if (camera.targetTexture != null)
        {
            camera.targetTexture.Release();
        }
        //camera1LeftEye.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        camera.targetTexture = new RenderTexture(2016, 2240, 24);
        cameraTextureMat.mainTexture = camera.targetTexture;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 eyeOffsetFromPortal = duplicatedEye.position - otherPortal.position;
        //transform.position = portal.position + eyeOffsetFromPortal;

        //float angularDiffBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        //Quaternion portalRotationDifference = Quaternion.AngleAxis(angularDiffBetweenPortalRotations, Vector3.up);

        //Vector3 newCameraDirection = portalRotationDifference * duplicatedEye.forward;
        //transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);

        //transform.rotation = duplicatedEye.rotation;

        Vector3 eyePosInOtherRoom = otherRoom.InverseTransformPoint(duplicatedEye.position);
        transform.position = thisRoom.TransformPoint(eyePosInOtherRoom);

        Quaternion eyeRotationInOtherRoom = Quaternion.Inverse(otherRoom.rotation) * duplicatedEye.rotation;
        transform.rotation = thisRoom.rotation * eyeRotationInOtherRoom;
    }
}
