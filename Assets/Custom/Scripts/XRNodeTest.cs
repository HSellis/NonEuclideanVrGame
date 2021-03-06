using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class XRNodeTest : MonoBehaviour
{
    public List<XRNodeState> nodeStates;
    private XRNodeState single_xrnode;

    private Vector3 left_eye_pos, right_eye_pos;
    private Quaternion left_eye_rot, right_eye_rot;

    public Transform headset;
    public Transform leftEye;
    public Transform rightEye;

    // Start is called before the first frame update
    void Start()
    {
        nodeStates = new List<XRNodeState>();

        // Add left eye node to the nodeStates list, which will be represented by nodeStates[0]
        single_xrnode.nodeType = XRNode.LeftEye;
        nodeStates.Add(single_xrnode);

        // Add right eye node to the nodeStates list, which will be represented by nodeStates[1]
        single_xrnode.nodeType = XRNode.RightEye;
        nodeStates.Add(single_xrnode);

    }

    // Update is called once per frame
    void Update()
    {
        InputTracking.GetNodeStates(nodeStates);

        // Try to get the parameters and place them into the correct variables
        nodeStates[0].TryGetPosition(out left_eye_pos);
        nodeStates[0].TryGetRotation(out left_eye_rot);

        nodeStates[1].TryGetPosition(out right_eye_pos);
        nodeStates[1].TryGetRotation(out right_eye_rot);


        Debug.Log(left_eye_pos - right_eye_pos);
        Debug.Log(left_eye_pos - headset.position);
        Debug.Log(right_eye_pos - headset.position);

        leftEye.position = left_eye_pos;
        leftEye.rotation = left_eye_rot;
        rightEye.position = right_eye_pos;
        rightEye.rotation = right_eye_rot;
    }
}