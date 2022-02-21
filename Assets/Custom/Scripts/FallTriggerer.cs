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

    private void OnCollisionEnter(Collision collision)
    {
        roomRigidbody.useGravity = true;
    }
}
