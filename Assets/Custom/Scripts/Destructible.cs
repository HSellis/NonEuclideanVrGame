using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public Destructible duplicate;

    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Hammer")
        {
            if (collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 1)
            {
                Destroy(duplicate.gameObject);
                Destroy(gameObject);
                
            }
            
        }
    }


}
