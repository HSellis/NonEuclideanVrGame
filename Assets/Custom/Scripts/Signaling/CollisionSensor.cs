using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSensor : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameController" || other.tag == "FreelyMovable")
        {
            meshRenderer.material = activeMat;
            activatable.Activate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "GameController" || other.tag == "FreelyMovable")
        {
            meshRenderer.material = inactiveMat;
            activatable.Deactivate();
        }
    }
}
