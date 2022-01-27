using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Grabbable : MonoBehaviour
{
    public bool freelyMovable;
    public ControllerGrabObject holdingHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void StartHolding(ControllerGrabObject hand);

    public abstract void StopHolding(ControllerGrabObject hand);
}
