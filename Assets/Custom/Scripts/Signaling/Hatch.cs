using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatch : Activatable
{
    public Transform hatchHolder;

    private SpringJoint spring;

    // Start is called before the first frame update
    void Start()
    {
        spring = GetComponent<SpringJoint>();
        spring.maxDistance = 0;

        hatchHolder.position += new Vector3(0.125f, 0, -0.125f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activate()
    {
        spring.maxDistance = 0.75f;
        Debug.Log("spring distance:");
        Debug.Log(spring.maxDistance);
    }

    public override void Deactivate()
    {
        spring.maxDistance = 0;
        Debug.Log("spring distance:");
        Debug.Log(spring.maxDistance);
    }
}
