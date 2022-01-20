using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Grabbable : MonoBehaviour
{
    public bool freelyMovable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void StartHolding(GameObject hand);

    public abstract void StopHolding(GameObject hand);
}
