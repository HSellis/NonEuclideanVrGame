using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Grabbable
{
    public DoorLock doorLock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toLock = doorLock.transform.position - transform.position;
        if (toLock.magnitude <= 0.1)
        {
            doorLock.Activate();
        }
    }

    public override void StartHolding(GameObject hand)
    {
        
    }

    public override void StopHolding(GameObject hand)
    {
        
    }
}
