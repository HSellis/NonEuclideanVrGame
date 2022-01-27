using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public List<string> activeRooms; // rooms where this portal's cameras should actively render

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
        bool activity = activeRooms.Contains(roomName);
        foreach (Transform child in transform)
        {
            if (child.gameObject.name.StartsWith("Camera")) {
                child.gameObject.SetActive(activity);
            }
        }
    }
}
