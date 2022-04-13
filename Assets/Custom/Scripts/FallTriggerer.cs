using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTriggerer : MonoBehaviour
{
    public Rigidbody roomRigidbody;
    public Destructible glass;
    public float glassBreakingForce = 0.25f;

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
            glass.Break(other.transform.position, glassBreakingForce);
            roomRigidbody.useGravity = true;
        }
    }
}
