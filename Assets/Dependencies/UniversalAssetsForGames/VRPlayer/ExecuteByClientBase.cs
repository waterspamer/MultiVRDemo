using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ExecuteByClientBase : NetworkBehaviour
{

    public DragRay DragRay;
    public static ExecuteByClientBase Current;
    
    void Start() {
        if (isLocalPlayer) {
            Current = this;
        }
    }

    [Command]
    public void CmdSetRay(Vector3 pos, NetworkInstanceId ownerId) {
        //Debug.Log("CmdSetRay");
        RpcSetRay(pos, ownerId);
    }
    [ClientRpc]
    void RpcSetRay(Vector3 pos, NetworkInstanceId ownerId) {
        //Debug.Log("RpcSetRay");
        if (ClientPlayer.CurrentPlayerNetId != ownerId) {
            //Debug.Log("netId = " + netId + "  ownerId = " + ownerId);
            DragRay.SetParentPointPosition(pos);
        }
    }

}
