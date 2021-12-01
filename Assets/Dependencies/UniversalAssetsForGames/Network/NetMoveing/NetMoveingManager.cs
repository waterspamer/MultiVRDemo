using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetMoveingManager : NetworkBehaviour {

    public static NetMoveingManager CurrentPlayerNetMoveingManager;
    
    void Start() {
        if (isLocalPlayer) {
            Debug.Log("isLocalPlayer");
            CurrentPlayerNetMoveingManager = this;
        }
    }

    public void SetOwnerNetId(NetworkInstanceId networkInstanceIdOfObject, int arrayIndex, bool grab) {
        CmdSetOwnerNetId(grab ? ClientPlayer.CurrentPlayerNetId : NetworkInstanceId.Invalid, networkInstanceIdOfObject, arrayIndex);
    }
    [Command]
    void CmdSetOwnerNetId(NetworkInstanceId networkInstanceIdOfPlayer, NetworkInstanceId networkInstanceIdOfObject, int arrayIndex) {
        GameObject obj = NetworkServer.FindLocalObject(networkInstanceIdOfObject);
        Debug.Log(obj, obj);
        if (obj == null)
        {
            return;
        }
        obj.GetComponent<NetPositions>().SetOwnerNetId(networkInstanceIdOfPlayer, arrayIndex);
        //если Ungrab
        if (networkInstanceIdOfPlayer == NetworkInstanceId.Invalid) {

        }
        RpcSetOwnerNetId(networkInstanceIdOfPlayer, networkInstanceIdOfObject, arrayIndex);
    }
    [ClientRpc]
    void RpcSetOwnerNetId(NetworkInstanceId networkInstanceIdOfPlayer, NetworkInstanceId networkInstanceIdOfObject, int arrayIndex) {
        ClientScene.FindLocalObject(networkInstanceIdOfObject)?.GetComponent<NetPositions>()?.SetOwnerNetId(networkInstanceIdOfPlayer, arrayIndex);
    }


    public void ProvidePoseToServer(Vector3 position, Quaternion rotation, NetworkInstanceId networkInstanceIdOfObject, int arrayIndex) {
        CmdProvidePoseToServer(position, rotation, networkInstanceIdOfObject, netId, arrayIndex);
    }
    [Command]
    void CmdProvidePoseToServer(Vector3 position, Quaternion rotation, NetworkInstanceId networkInstanceIdOfObject, NetworkInstanceId networkInstanceIdOfPlayer, int arrayIndex) {
        RpcProvidePose(position, rotation, networkInstanceIdOfObject, networkInstanceIdOfPlayer, arrayIndex);
    }
    [ClientRpc]
    void RpcProvidePose(Vector3 position, Quaternion rotation, NetworkInstanceId networkInstanceIdOfObject, NetworkInstanceId networkInstanceIdOfPlayer, int arrayIndex) {
        if (networkInstanceIdOfPlayer == ClientPlayer.CurrentPlayerNetId) return;
        GameObject obj = ClientScene.FindLocalObject(networkInstanceIdOfObject);
        if (obj) {
            NetPositions netPositions = obj.GetComponent<NetPositions>();
            if (netPositions) {
                Transform objTransform = netPositions.NetMoveingRayButtonArray[arrayIndex].transform;
                objTransform.position = position;
                objTransform.rotation = rotation;
            }
        }
    }
    

    // Unpress on server
    public void Unpress(Vector3 position, Quaternion rotation, NetworkInstanceId networkInstanceIdOfObject, int arrayIndex) {
        CmdUnpress(position, rotation, networkInstanceIdOfObject, arrayIndex);
    }
    [Command]
    void CmdUnpress(Vector3 position, Quaternion rotation, NetworkInstanceId networkInstanceIdOfObject, int arrayIndex) {
        GameObject obj = NetworkServer.FindLocalObject(networkInstanceIdOfObject);
        if (obj == null)
        {
            return;
        }
        NetPositions netPositions = obj.GetComponent<NetPositions>();
        if (netPositions) {
            Transform objTransform = netPositions.NetMoveingRayButtonArray[arrayIndex].transform;
            objTransform.position = position;
            objTransform.rotation = rotation;
            obj.GetComponent<NetMoveingRayButton>().UnpressByServer();
        }
    }




    // Unpress on server
    public void Press(NetworkInstanceId networkInstanceIdOfObject, int arrayIndex) {
        CmdPress(networkInstanceIdOfObject, arrayIndex);
    }
    [Command]
    void CmdPress(NetworkInstanceId networkInstanceIdOfObject, int arrayIndex) {
        GameObject obj = NetworkServer.FindLocalObject(networkInstanceIdOfObject);
        if (obj == null)
        {
            return;
        }
        obj.GetComponent<NetMoveingRayButton>().PressByServer();
    }


}
