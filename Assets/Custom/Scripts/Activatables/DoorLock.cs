using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : Activatable
{
    public int necessarySignals;
    public int currentSignals = 0;

    public Material lockedColour;
    public Material unlockedColour;

    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = isLocked() ? lockedColour : unlockedColour;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activate()
    {
        currentSignals += 1;
        meshRenderer.material = isLocked() ? lockedColour : unlockedColour;
    }

    public override void Deactivate()
    {
        currentSignals -= 1;
        meshRenderer.material = isLocked() ? lockedColour : unlockedColour;
    }

    public bool isLocked()
    {
        return currentSignals < necessarySignals;
    }
}
