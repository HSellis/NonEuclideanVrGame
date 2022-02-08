using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GameController : MonoBehaviour
{
    public string startRoom;

    private void Awake()
    {
        XRSettings.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        TeleportEvents.PlayerEnteredRoom(startRoom);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
