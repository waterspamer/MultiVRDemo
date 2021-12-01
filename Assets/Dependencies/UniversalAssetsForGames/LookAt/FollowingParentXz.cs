using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingParentXz : MonoBehaviour {

    public Transform Parent;

    void LateUpdate() {

        transform.position = Parent.position;
        Vector3 frowardProjection = new Vector3(Parent.forward.x, 0f, Parent.forward.z);
        Quaternion targetRotation = Quaternion.LookRotation(frowardProjection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5f);

    }

}
