using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetRay : NetworkBehaviour {

    public Transform ParentPoint;
    public Transform RayStart;
    
    void FixedUpdate() {
        if (isLocalPlayer) {
            CmdSetRay(ParentPoint.position, RayStart.localScale.z, ClientPlayer.CurrentPlayerNetId);
        }
    }

    [Command]
    void CmdSetRay(Vector3 pointPosition, float rayLength, NetworkInstanceId ownerNetId) {
        RpcSetRay(pointPosition, rayLength, ownerNetId);
    }

    [ClientRpc]
    void RpcSetRay(Vector3 pointPosition, float rayLength, NetworkInstanceId ownerNetId) {
        if(ClientPlayer.CurrentPlayerNetId == ownerNetId) return;
        ParentPoint.position = pointPosition;
        RayStart.localScale = new Vector3(1f, 1f, rayLength);
    }

}
