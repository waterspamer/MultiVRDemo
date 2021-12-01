using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerScale : MonoBehaviour {

    public Transform CameraTransform;
    public Transform DotVisualTransform;
    public float DotScaleMult = 0.05f;

    void LateUpdate() {
        float dotScale = Vector3.Distance(CameraTransform.position, DotVisualTransform.position) * DotScaleMult;
        DotVisualTransform.localScale = new Vector3(dotScale, dotScale, dotScale);
    }

}
