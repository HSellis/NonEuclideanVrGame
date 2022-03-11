using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    private Vector3 origLocalPos;

    // Start is called before the first frame update
    void Start()
    {
        origLocalPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GameController")
        {
            transform.DOLocalMove(origLocalPos + new Vector3(0, -0.01f, 0), 0.5f);
            Invoke("ChangeScene", 1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "GameController")
        {
            transform.DOLocalMove(origLocalPos, 0.5f);
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
