using UnityEngine;
using Valve.VR;

public class ActionsTest : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean grabAction;

    // Update is called once per frame
    void Update()
    {
        if (GetGrab())
        {
            Debug.Log("grab" + handType);
        }
    }

    public bool GetGrab()
    {
        return grabAction.GetState(handType);
    }
}
