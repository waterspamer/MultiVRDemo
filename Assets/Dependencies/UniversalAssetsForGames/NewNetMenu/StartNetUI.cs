using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIState{
    Loading,
    HostNotFound,
    HostFound
    
}

public class StartNetUI : MonoBehaviour
{
    public string Tag = "Head";
    private Transform _targetTransform;
    private Transform _mainCameraTransform;

    void LateUpdate() {

        if (_targetTransform != null) {
            transform.position = _targetTransform.position;
            //transform.rotation = _targetTransform.rotation;
            if(!_mainCameraTransform){
                _mainCameraTransform = Camera.main.transform;
            }else{
                Vector3 cameraXZ = new Vector3(_mainCameraTransform.forward.x, 0f, _mainCameraTransform.forward.z);
                transform.rotation = Quaternion.LookRotation(cameraXZ, Vector3.up);
            }
        } else {
            FollowingByTagTarget followingByTagTarget = FollowingByTagTargetCollection.Instance.FindTaget(Tag);
            
            if (followingByTagTarget) {
                _targetTransform = followingByTagTarget.transform;
            }
        }

    }


}

