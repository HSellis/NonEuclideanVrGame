using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public List<string> activeRooms;

    // Start is called before the first frame update
    void Awake()
    {
        TeleportEvents.OnPlayerEnteredRoom += OnPlayerEnteredRoom;
    }

    private void OnDestroy()
    {
        TeleportEvents.OnPlayerEnteredRoom -= OnPlayerEnteredRoom;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPlayerEnteredRoom(string roomName)
    {
        if (activeRooms.Contains(roomName)) {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
