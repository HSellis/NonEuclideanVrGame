using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : Activatable
{
    public List<Rigidbody> doors = new List<Rigidbody>();

    public int necessarySignals = 0;
    private int currentSignals = 0;

    public Material lockedColour;
    public Material unlockedColour;

    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        if (doors.Count == 0)
        {
            doors.Add(transform.parent.GetComponent<Rigidbody>());
        }
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

            foreach (Rigidbody rb in doors)
            {
                FixedJoint fixer = rb.gameObject.AddComponent<FixedJoint>();
                fixer.connectedBody = rb.gameObject.GetComponent<HingeJoint>().connectedBody;
            }
        }
        else {
            meshRenderer.material = unlockedColour;

            foreach (Rigidbody rb in doors)
            {
                FixedJoint fixer = rb.gameObject.GetComponent<FixedJoint>();
                if (fixer != null) Destroy(fixer);
            }
        }
    }
}
