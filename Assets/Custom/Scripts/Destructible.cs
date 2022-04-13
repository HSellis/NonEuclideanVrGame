using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public AudioClip breakingSound;

    public float explosionForce = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("Hammer"))
        {

            Rigidbody hammerBody = other.gameObject.GetComponent<Rigidbody>();
            Debug.Log(hammerBody.velocity.magnitude);
            Debug.Log(hammerBody.angularVelocity.magnitude);
            if (hammerBody.velocity.magnitude + hammerBody.angularVelocity.magnitude > 1.5f)
            {
                Vector3 hammerPos = other.gameObject.transform.position;
                Break(hammerPos, explosionForce);
            }

        }
    }

    public void Break(Vector3 breakingPoint, float force)
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (audio != null && breakingSound != null)
        {
            audio.clip = breakingSound;
            audio.Play();
        }
        

        foreach (Rigidbody rb in transform.GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = false;
            rb.AddExplosionForce(force, breakingPoint, 0.5f);

            Duplicater dupl = rb.GetComponent<Duplicater>();
            if (dupl)
            {
                dupl.isChangeLocked = false;
                dupl.duplicate.isChangeLocked = false;
            }
        }
    }

}
