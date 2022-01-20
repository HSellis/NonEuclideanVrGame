using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : Activatable
{
    public bool isLocked = true;
    public GameObject doorLock;

    public Material lockedColour;
    public Material unlockedColour;

    private MeshRenderer lockMeshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lockMeshRenderer = doorLock.GetComponent<MeshRenderer>();
        lockMeshRenderer.material = isLocked ? lockedColour : unlockedColour;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activate()
    {
        isLocked = false;
        lockMeshRenderer.material = unlockedColour;
    }

    public override void Deactivate()
    {
        isLocked = true;
        lockMeshRenderer.material = lockedColour;
    }
}
