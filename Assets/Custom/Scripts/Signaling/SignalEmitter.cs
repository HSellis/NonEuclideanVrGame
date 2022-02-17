using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalEmitter : MonoBehaviour
{
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
        Activatable collidedActivatable = other.GetComponent<Activatable>();
        if (collidedActivatable)
        {
            collidedActivatable.Activate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Activatable collidedActivatable = other.GetComponent<Activatable>();
        if (collidedActivatable)
        {
            collidedActivatable.Deactivate();
        }
    }
}
