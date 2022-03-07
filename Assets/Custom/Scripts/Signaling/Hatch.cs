using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hatch : Activatable
{
    private Vector3 origPos;


    // Start is called before the first frame update
    void Start()
    {
        origPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activate()
    {
        transform.DOMove(origPos + new Vector3(0, 0.875f, 0), 1);
    }

    public override void Deactivate()
    {
        transform.DOMove(origPos, 1);
    }
}
