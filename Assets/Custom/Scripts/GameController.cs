using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GameController : MonoBehaviour
{

    private void Awake()
    {
        XRSettings.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        Transform playerRoom = GameObject.Find("[CameraRig]").transform.parent;
        TeleportEvents.PlayerEnteredRoom(playerRoom.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
