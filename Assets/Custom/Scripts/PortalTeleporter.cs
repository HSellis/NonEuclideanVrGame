using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform playArea;
    public Transform destinationRoom;
    

    //private bool playerOverlap = false;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        /*
        if (playerOverlap)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
            Debug.Log("dot product: " + dotProduct);
            if (dotProduct < 0f)
            {
                float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = receiver.position + positionOffset;

                playerOverlap = false;
            }
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 portalToOther = other.transform.position - transform.position;
        float dotProduct = Vector3.Dot(transform.up, portalToOther);
        Debug.Log("dot product: " + dotProduct);

            
        if (dotProduct > 0f)
        {
            if (other.tag == "Player")
            {
                playArea.parent = destinationRoom;
                playArea.localPosition = new Vector3(0, 0, 0);
                playArea.localRotation = Quaternion.Euler(0, 0, 0);
                
                //float rotationDiff = -Quaternion.Angle(playArea.rotation, destinationRoom.rotation);
                //rotationDiff += 180;
                //playArea.Rotate(Vector3.up, rotationDiff);

                //playArea.position = destinationRoom.position;
            } 

        }
    }

}
