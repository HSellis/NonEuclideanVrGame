using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalWire : Activatable
{
    public Activatable activatable;
    public Material activeMat;
    public Material inactiveMat;

    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = inactiveMat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activate()
    {
        meshRenderer.material = activeMat;
        activatable.Activate();
    }

    public override void Deactivate()
    {
        meshRenderer.material = inactiveMat;
        activatable.Deactivate();
    }
}
