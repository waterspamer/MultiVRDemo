using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingByTag : MonoBehaviour {

    public string Tag;
    private Transform _targetTransform;
    public Quaternion offestRot = new Quaternion(0,0,0,1);

    private void OnEnable()
    {
        ResetTarget();
        FollowingByTagTargetCollection.Instance.OnTargetsUpdate += ResetTarget;
    }

    private void OnDisable()
    {
        FollowingByTagTargetCollection.Instance.OnTargetsUpdate -= ResetTarget;
    }

    private void ResetTarget() {
        _targetTransform = null;
    }

    void LateUpdate() {
        if (_targetTransform != null) {
            transform.position = _targetTransform.position;
            transform.rotation = _targetTransform.rotation * offestRot;
        } else {
            FollowingByTagTarget followingByTagTarget = FollowingByTagTargetCollection.Instance.FindTaget(Tag);
            if (followingByTagTarget) {
                _targetTransform = followingByTagTarget.transform;
            }
        }
    }


}
