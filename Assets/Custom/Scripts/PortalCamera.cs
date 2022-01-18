using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    private new Camera camera;
    public Material cameraTextureMat;

    public Transform duplicatedEye;
    
    public Transform thisRoom;
    public Transform otherRoom;

    
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

    
    void Update()
    {

        Vector3 eyePosRelativeToOtherRoom = otherRoom.InverseTransformPoint(duplicatedEye.position);
        transform.position = thisRoom.TransformPoint(eyePosRelativeToOtherRoom);

        Quaternion eyeRotationRelativeToOtherRoom = Quaternion.Inverse(otherRoom.rotation) * duplicatedEye.rotation;
        transform.rotation = thisRoom.rotation * eyeRotationRelativeToOtherRoom;
    }
}
