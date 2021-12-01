using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetPositions : NetworkBehaviour {

    public NetMoveingRayButton[] NetMoveingRayButtonArray;
    public NetworkInstanceId[] OwnerNetIdArray;
    //public Text[] TextArray;

    void Awake() {
        for (int i = 0; i < NetMoveingRayButtonArray.Length; i++) {
            NetMoveingRayButtonArray[i].ArrayIndex = i;
        }
        OwnerNetIdArray = new NetworkInstanceId[NetMoveingRayButtonArray.Length];
        for (int i = 0; i < OwnerNetIdArray.Length; i++) {
            OwnerNetIdArray[i] = NetworkInstanceId.Invalid;
        }

    }

    void Start() {
        for (int i = 0; i < OwnerNetIdArray.Length; i++) {
            OwnerNetIdArray[i] = NetworkInstanceId.Invalid;
        }
    }

    void FixedUpdate() {
        for (int i = 0; i < NetMoveingRayButtonArray.Length; i++) {
            if (OwnerNetIdArray[i] == ClientPlayer.CurrentPlayerNetId) {
                NetMoveingManager.CurrentPlayerNetMoveingManager.ProvidePoseToServer(
                    NetMoveingRayButtonArray[i].transform.position,
                    NetMoveingRayButtonArray[i].transform.rotation,
                    GetComponent<NetworkIdentity>().netId,
                    i
                    );
            }
        }
    }

    public void SetOwnerNetId(NetworkInstanceId networkInstanceId, int arrayIndex) {
        OwnerNetIdArray[arrayIndex] = networkInstanceId;
        // Надо проверять еще и длину массива, иначе будут ошибки при пустом массиве
        //if (TextArray[arrayIndex]) {
        //    TextArray[arrayIndex].text = networkInstanceId.ToString();
        //}
    }

}
