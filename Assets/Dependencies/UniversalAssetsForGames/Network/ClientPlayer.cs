using System;
using System.Collections;
using System.Collections.Generic;
//using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Networking;

public class ClientPlayer : NetworkBehaviour {

    public Transform[] NetTransforms;
    private int _n;
    public float LerpRate = 20f;
    [SerializeField] private int _sendEveryNFrame = 3;

    public Behaviour[] LocalPlayerOnlyBehaviours;

    public static NetworkInstanceId CurrentPlayerNetId;
    
    private Vector3[] _targetPositions = new Vector3[0];
    private Quaternion[] _targetRotations = new Quaternion[0];
    
    void Start() {
        if (isLocalPlayer) {
            CurrentPlayerNetId = netId;
            //Debug.Log(CurrentPlayerNetId);
        } else {
            for (int i = 0; i < NetTransforms.Length; i++) {
                if (NetTransforms[i].GetComponent<FollowingByTag>()) {  // вероятно тут стоит использовать интерфейс
                    NetTransforms[i].GetComponent<FollowingByTag>().enabled = false;
                }
            }
            for (int i = 0; i < LocalPlayerOnlyBehaviours.Length; i++) {
                LocalPlayerOnlyBehaviours[i].enabled = false;
            }
        }
    }

    void Update() {
        if (!isLocalPlayer) {
            for (int i = 0; i < NetTransforms.Length; i++) {
                if (_targetPositions.Length == NetTransforms.Length) {
                    if (!float.IsNaN(_targetPositions[i].x) && !float.IsNaN(_targetPositions[i].y) && !float.IsNaN(_targetPositions[i].z)) {
                        NetTransforms[i].position = Vector3.Lerp(NetTransforms[i].position, _targetPositions[i], Time.deltaTime * LerpRate);
                        NetTransforms[i].rotation = Quaternion.Lerp(NetTransforms[i].rotation, _targetRotations[i], Time.deltaTime * LerpRate);
                    }
                }
            }
        }
    }
    
    void FixedUpdate() {
        if (isLocalPlayer) {
            _n++;
            if (_n == _sendEveryNFrame) {
                _n = 0;

                Vector3[] positionsArray = new Vector3[NetTransforms.Length];
                Quaternion[] rotationsArray = new Quaternion[NetTransforms.Length];

                for (int i = 0; i < NetTransforms.Length; i++) {
                    positionsArray[i] = NetTransforms[i].position;
                    rotationsArray[i] = NetTransforms[i].rotation;
                }

                CmdProvidePositionsToServer(positionsArray, rotationsArray);
            }
        }
    }

    [Command(channel = 0)]
    void CmdProvidePositionsToServer(Vector3[] positions, Quaternion[] rotations) {
        SetTargetPoses(positions, rotations);
        RpcProvidePositionsToClient(positions, rotations);
    }
    
    [ClientRpc(channel = 0)]
    void RpcProvidePositionsToClient(Vector3[] positions, Quaternion[] rotations) {
        SetTargetPoses(positions, rotations);
    }

    void SetTargetPoses(Vector3[] positions, Quaternion[] rotations) {
        _targetPositions = positions;
        _targetRotations = rotations;
    }

}

