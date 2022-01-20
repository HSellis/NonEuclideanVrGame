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
        Debug.Log("dot product: " + dotProduct);

            
        if (dotProduct > 0f)
        {
            if (other.tag == "Player")
            {
                playArea.parent = destinationRoom;
                playArea.localPosition = new Vector3(0, 0, 0);
                playArea.localRotation = Quaternion.Euler(0, 0, 0);
                
            } 

        }
    }

}
