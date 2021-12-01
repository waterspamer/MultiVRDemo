using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetMoveingRayButton : RayButton {
    
    private bool _grabbed;
    [SerializeField]
    private NetPositions NetPositions;
    [SerializeField]
    private NetworkIdentity NetworkIdentity;
    [HideInInspector]
    public int ArrayIndex;
    

    public override void OnPress(DragRay dragRay) {
        
        base.OnPress(dragRay);

        NetMoveingManager.CurrentPlayerNetMoveingManager.Press(NetworkIdentity.netId, ArrayIndex);
        if (NetPositions.OwnerNetIdArray[ArrayIndex] == NetworkInstanceId.Invalid) {
            NetMoveingManager.CurrentPlayerNetMoveingManager.SetOwnerNetId(NetworkIdentity.netId, ArrayIndex, true);
            transform.SetParent(dragRay.ParentPoint);
            _grabbed = true;
        }

    }

    public override void OnUnpress(DragRay dragRay) {

        base.OnUnpress(dragRay);
        
        NetMoveingManager.CurrentPlayerNetMoveingManager.Unpress(transform.position, transform.rotation, NetworkIdentity.netId, ArrayIndex);
        if (_grabbed) {
            NetMoveingManager.CurrentPlayerNetMoveingManager.SetOwnerNetId(NetworkIdentity.netId, ArrayIndex, false);
            transform.SetParent(null);
            _grabbed = false;
        }
        
    }

    public virtual void UnpressByServer() {
    }

    public virtual void PressByServer() {
    }

}


