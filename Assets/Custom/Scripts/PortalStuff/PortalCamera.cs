using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PortalCamera : MonoBehaviour
{
    private new Camera camera;
    public Material cameraTextureMat;

    public Transform duplicatedEye;
    
    public Transform thisRoom;
    public Transform otherRoom;

    //private float verticalFoV = 85;
    //private float horizontalFoV = 82;

    
    void Start()
    {
        camera = GetComponent<Camera>();
        if (camera.targetTexture != null)
        {
            camera.targetTexture.Release();
        }
        
        //camera1LeftEye.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        //camera.targetTexture = new RenderTexture(2016, 2240, 24); // HTC Vive
        //camera.targetTexture = new RenderTexture(1832, 1920, 24); // Oculus Quest 2
        camera.targetTexture = new RenderTexture(1032, 1220, 24); // Oculus Quest 2
        cameraTextureMat.mainTexture = camera.targetTexture;

        //camera.aspect = horizontalFoV / verticalFoV;
        //Debug.Log("aspect ratio: " + camera.aspect);
        //camera.fieldOfView = verticalFoV;

        Debug.Log("XR enabled: " + XRSettings.enabled);
        Debug.Log("height: " + XRSettings.eyeTextureHeight);
        Debug.Log("width: " + XRSettings.eyeTextureWidth);
        Debug.Log("dimension: " + XRSettings.deviceEyeTextureDimension);
        Debug.Log("resolution scale: " + XRSettings.eyeTextureResolutionScale);
        Debug.Log("render viewport scale: " + XRSettings.renderViewportScale);
        Debug.Log("is device active: " + XRSettings.isDeviceActive);
    }

    
    void LateUpdate()
    {

        Vector3 eyePosRelativeToOtherRoom = otherRoom.InverseTransformPoint(duplicatedEye.position);
        transform.position = thisRoom.TransformPoint(eyePosRelativeToOtherRoom);

        Quaternion eyeRotationRelativeToOtherRoom = Quaternion.Inverse(otherRoom.rotation) * duplicatedEye.rotation;
        transform.rotation = thisRoom.rotation * eyeRotationRelativeToOtherRoom;
    }

}
