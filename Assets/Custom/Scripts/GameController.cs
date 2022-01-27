using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public string startRoom;

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
