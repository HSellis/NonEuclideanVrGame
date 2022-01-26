using UnityEngine;
using System;

public static class TeleportEvents
{
    public static event Action<string> OnPlayerEnteredRoom;
    public static void PlayerEnteredRoom(string roomName) => OnPlayerEnteredRoom?.Invoke(roomName);

    public static event Action<GameObject, string> OnObjectEnteredRoom;
    public static void ObjectEnteredRoom(GameObject obj, string roomName) => OnObjectEnteredRoom?.Invoke(obj, roomName);
}
