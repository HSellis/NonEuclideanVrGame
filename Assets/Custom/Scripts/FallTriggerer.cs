using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTriggerer : MonoBehaviour
{
    public Rigidbody roomRigidbody;

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
        if (other.tag == "FreelyMovable" || other.tag == "Player")
        {
            GetComponent<Rigidbody>().useGravity = true;
            roomRigidbody.useGravity = true;
        }
    }
}
