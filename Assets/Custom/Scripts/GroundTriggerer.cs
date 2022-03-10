using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTriggerer : MonoBehaviour
{
    public Transform fromRoom;
    public Transform destinationRoom;
    public Transform playArea;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == fromRoom)
        {
            playArea.parent = destinationRoom;
            playArea.localPosition = Vector3.zero;
            playArea.localRotation = Quaternion.identity;
            Rigidbody fromRoomRigidbody = fromRoom.GetComponent<Rigidbody>();
            fromRoomRigidbody.useGravity = false;
            fromRoomRigidbody.velocity = Vector3.zero;
        }
    }
}
