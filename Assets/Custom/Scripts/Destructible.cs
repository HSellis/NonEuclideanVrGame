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
        Debug.Log("collision: " + collision.gameObject.name);
        if (collision.gameObject.name.StartsWith("Hammer"))
        {
            Rigidbody hammerBody = collision.gameObject.GetComponent<Rigidbody>();
            Debug.Log(hammerBody.velocity.magnitude);
            Debug.Log(hammerBody.angularVelocity.magnitude);
            if (hammerBody.velocity.magnitude + hammerBody.angularVelocity.magnitude > 1.5f)
            {
                Destroy(duplicate.gameObject);
                Destroy(gameObject);
                
            }
            
        }
    }


}
