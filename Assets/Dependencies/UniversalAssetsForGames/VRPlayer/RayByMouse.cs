using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayByMouse : MonoBehaviour {

    public Transform RayTransform;
    public Camera Camera;

    void LateUpdate() {
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f)) {
            RayTransform.LookAt(hit.point);
        }
    }

}
