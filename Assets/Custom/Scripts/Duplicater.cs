using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duplicater : MonoBehaviour
{
    public Transform thisRoom;
    public Transform otherRoom;

    public Duplicater duplicate;
    public bool isSource;
    public bool isChangeLocked = false;

    private Rigidbody rigidBody;
    private Rigidbody duplicateRigidBody;

    private float scaleDiff;

    // Start is called before the first frame update
    void Start()
    {
        TeleportEvents.OnPlayerEnteredRoom += OnPlayerEnteredRoom;
        TeleportEvents.OnObjectEnteredRoom += OnObjectEnteredRoom;

        rigidBody = GetComponent<Rigidbody>();
        duplicateRigidBody = duplicate.GetComponent<Rigidbody>();

        scaleDiff = transform.localScale.x / duplicate.transform.localScale.x;
    }

    private void OnDestroy()
    {
        TeleportEvents.OnPlayerEnteredRoom -= OnPlayerEnteredRoom;
        TeleportEvents.OnObjectEnteredRoom -= OnObjectEnteredRoom;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isSource)
        {
            if ((duplicate.transform.position - duplicate.thisRoom.position).sqrMagnitude > 100) return; // duplicate was teleported

            transform.position = transformPosBetweenRooms(otherRoom, thisRoom, duplicate.transform.position);
            transform.rotation = transformRotationBetweenRooms(otherRoom, thisRoom, duplicate.transform.rotation);
            rigidBody.velocity = transformVectorBetweenRooms(otherRoom, thisRoom, duplicateRigidBody.velocity);
            rigidBody.angularVelocity = duplicateRigidBody.angularVelocity;

        }
    }

    private Vector3 transformPosBetweenRooms(Transform fromRoom, Transform toRoom, Vector3 pos)
    {
        Vector3 posInFromRoom = fromRoom.InverseTransformPoint(pos);
        return toRoom.TransformPoint(posInFromRoom);
    }

    private Quaternion transformRotationBetweenRooms(Transform fromRoom, Transform toRoom, Quaternion rotation)
    {
        Quaternion rotationInFromRoom = Quaternion.Inverse(fromRoom.rotation) * rotation;
        return toRoom.rotation * rotationInFromRoom;
    }

    private Vector3 transformVectorBetweenRooms(Transform fromRoom, Transform toRoom, Vector3 vector)
    {
        Vector3 vectorInFromRoom = fromRoom.InverseTransformVector(vector);
        return toRoom.TransformVector(vectorInFromRoom);
    }


    private void OnPlayerEnteredRoom(string roomName)
    {
        if (roomName + "Static" == thisRoom.gameObject.name)
        {
            isSource = true;
            if (!isChangeLocked) rigidBody.isKinematic = false;
        } else
        {
            isSource = false;
            if (!isChangeLocked) rigidBody.isKinematic = true;
        }
    }

    private void OnObjectEnteredRoom(GameObject obj, string roomName)
    {
        /*
        if (obj == gameObject  && roomName + "Static" == otherRoom.gameObject.name)
        {
            // I was tp-d to other room
            Debug.Log("I was tp-d to other room");

            Transform temp = thisRoom;
            thisRoom = otherRoom;
            otherRoom = temp;

            SetSource(!isSource);

        }
        */

        if (obj == duplicate.gameObject && roomName + "Static" == thisRoom.gameObject.name)
        {
            // My duplicate was tp-d to my room

            // Teleport myself to other room
            transform.position = transformPosBetweenRooms(thisRoom, otherRoom, duplicate.transform.position);
            transform.rotation = transformRotationBetweenRooms(thisRoom, otherRoom, duplicate.transform.rotation);
            rigidBody.velocity = transformVectorBetweenRooms(thisRoom, otherRoom, duplicateRigidBody.velocity);
            rigidBody.angularVelocity = duplicateRigidBody.angularVelocity;


            // Switch rooms
            thisRoom = duplicate.thisRoom;
            otherRoom = duplicate.otherRoom;
            duplicate.thisRoom = otherRoom;
            duplicate.otherRoom = thisRoom;

            // I am now source, not my duplicate
            isSource = true;
            rigidBody.isKinematic = false;
            if (!isChangeLocked) duplicate.isSource = false;
            if (!duplicate.isChangeLocked) duplicateRigidBody.isKinematic = true;


            transform.localScale /= scaleDiff * scaleDiff;
        }
            
    }


}
