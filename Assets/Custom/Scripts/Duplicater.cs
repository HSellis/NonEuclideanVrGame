using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duplicater : MonoBehaviour
{
    public Transform roomCenter;
    public Transform otherRoomCenter;

    public Duplicater duplicate;
    public bool isFollowing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            Vector3 duplicatePosRelativeToOtherRoom = otherRoomCenter.InverseTransformPoint(duplicate.transform.position);
            
            transform.position = roomCenter.TransformPoint(duplicatePosRelativeToOtherRoom);

            Quaternion duplicateRotationRelativeToOtherRoom = Quaternion.Inverse(otherRoomCenter.rotation) * duplicate.transform.rotation;
            transform.rotation = roomCenter.rotation * duplicateRotationRelativeToOtherRoom;
        }
    }
}
