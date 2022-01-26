using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform playArea;
    public Transform destinationRoom;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 portalToOther = other.transform.position - transform.position;
        float dotProduct = Vector3.Dot(transform.up, portalToOther);
        //Debug.Log("dot product: " + dotProduct);

            
        if (dotProduct > 0f)
        {
            if (other.tag == "Player")
            {
                playArea.parent = destinationRoom;
                playArea.localPosition = new Vector3(0, 0, 0);
                playArea.localRotation = Quaternion.Euler(0, 0, 0);

                TeleportEvents.PlayerEnteredRoom(destinationRoom.gameObject.name);
                
            }
            else if (other.tag == "FreelyMovable")
            {
                Debug.Log("Teleporting object " + other.gameObject.name);
                Transform collidingTrans = other.transform;
                Rigidbody collidingRigidBody = other.GetComponent<Rigidbody>();
                Vector3 objectVelocity = collidingRigidBody.velocity;
                Vector3 objectAngularVelocity = collidingRigidBody.angularVelocity;
                
                Vector3 objectPosRelativeToThisRoom = playArea.InverseTransformPoint(collidingTrans.position);
                collidingTrans.position = destinationRoom.TransformPoint(objectPosRelativeToThisRoom);

                Quaternion objectRotationRelativeToThisRoom = Quaternion.Inverse(playArea.rotation) * collidingTrans.rotation;
                collidingTrans.rotation = destinationRoom.rotation * objectRotationRelativeToThisRoom;

                Vector3 objectVelocityRelativeToThisRoom = playArea.InverseTransformVector(objectVelocity);
                collidingRigidBody.velocity = destinationRoom.TransformVector(objectVelocityRelativeToThisRoom);

                collidingRigidBody.angularVelocity = objectAngularVelocity;

                TeleportEvents.ObjectEnteredRoom(other.gameObject, destinationRoom.gameObject.name);
            }

        }
    }

}
