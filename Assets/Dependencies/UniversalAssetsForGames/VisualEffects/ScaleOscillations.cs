using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOscillations : MonoBehaviour {

    private Vector3 StartScale;
    private Transform ThisTransform;

    public float OscillationsPercent;
    public float Period;

    [Range(0f,1f)]
    public float PhaseDifference = 0f;

    void Start() {
        ThisTransform = transform;
        StartScale = ThisTransform.localScale;
    }

    void LateUpdate() {
        float scale = 1f + Mathf.Sin( (Time.time + PhaseDifference) * 2f * Mathf.PI / Period) * OscillationsPercent;
        ThisTransform.localScale = StartScale * scale;
    }

}
