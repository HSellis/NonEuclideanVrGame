using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duplicater : MonoBehaviour
{
    public Transform thisRoom;
    public Transform otherRoom;
    public string bigRoomName;
    public string smallRoomName;

    public Duplicater duplicate;
    public bool isSource;

    // Start is called before the first frame update
    void Start()
    {
        TeleportEvents.OnPlayerEnteredRoom += OnPlayerEnteredRoom;
        TeleportEvents.OnObjectEnteredRoom += OnObjectEnteredRoom;
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

            Vector3 duplicatePosRelativeToOtherRoom = otherRoom.InverseTransformPoint(duplicate.transform.position);
            transform.position = thisRoom.TransformPoint(duplicatePosRelativeToOtherRoom);

            Quaternion duplicateRotationRelativeToOtherRoom = Quaternion.Inverse(otherRoom.rotation) * duplicate.transform.rotation;
            transform.rotation = thisRoom.rotation * duplicateRotationRelativeToOtherRoom;

        }
    }


    private void OnPlayerEnteredRoom(string roomName)
    {
        if (roomName + "Static" == thisRoom.gameObject.name)
        {
            isSource = true;
        } else
        {
            isSource = false;
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
            Debug.Log("My duplicate was tp-d to my room");

            isSource = !isSource;
            duplicate.isSource = !duplicate.isSource;

            //Transform temp = thisRoom;
            //thisRoom = otherRoom;
            //otherRoom = temp;
            thisRoom = duplicate.thisRoom;
            otherRoom = duplicate.otherRoom;
            duplicate.thisRoom = otherRoom;
            duplicate.otherRoom = thisRoom;



            if (roomName == bigRoomName)
            {
                // Going to small room
                Debug.Log("Going to small room");
                transform.localScale /= 9;
            }
            else if (roomName == smallRoomName)
            {
                // Going to big room
                Debug.Log("Going to big room");
                transform.localScale *= 9;
            }
        }

    }


}
