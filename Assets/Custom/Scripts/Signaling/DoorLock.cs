using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : Activatable
{
    public List<Rigidbody> doors;

    public int necessarySignals = 0;
    private int currentSignals = 0;

    public Material lockedColour;
    public Material unlockedColour;

    private MeshRenderer meshRenderer;
    private Rigidbody doorRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        doorRigidBody = transform.parent.GetComponent<Rigidbody>();
        controlStatus();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activate()
    {
        currentSignals += 1;
        controlStatus();
    }

    public override void Deactivate()
    {
        currentSignals -= 1;
        controlStatus();
    }

    public bool isLocked()
    {
        return currentSignals < necessarySignals;
    }

    private void controlStatus()
    {
        if (isLocked())
        {
            meshRenderer.material = lockedColour;
            if (doors == null) doorRigidBody.constraints = RigidbodyConstraints.FreezePosition;
            else
            {
                foreach (Rigidbody rb in doors)
                {
                    rb.constraints = RigidbodyConstraints.FreezePosition;
                }
            }
        }
        else {
            meshRenderer.material = unlockedColour;
            if (doors == null) doorRigidBody.constraints = RigidbodyConstraints.None;
            else
            {
                foreach (Rigidbody rb in doors)
                {
                    rb.constraints = RigidbodyConstraints.None;
                }
            }
        }
    }
}
