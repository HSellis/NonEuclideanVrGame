using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : Activatable
{
    public bool isLocked = true;

    public Material lockedColour;
    public Material unlockedColour;

    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = isLocked ? lockedColour : unlockedColour;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activate()
    {
        isLocked = false;
        meshRenderer.material = unlockedColour;
    }

    public override void Deactivate()
    {
        isLocked = true;
        meshRenderer.material = lockedColour;
    }
}
