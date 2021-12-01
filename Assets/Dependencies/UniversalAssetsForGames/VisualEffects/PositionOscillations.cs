using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionOscillations : MonoBehaviour
{
    private Vector3 _startLocalPosition;
    private Transform ThisTransform;

    public Vector3 MaxLocalPositionOffset;
    public float Period;

    [Range(0f,1f)]
    public float PhaseDifference = 0f;

    void Start() {
        ThisTransform = transform;
        _startLocalPosition = ThisTransform.localPosition;
    }

    void LateUpdate() {
        float scale = Mathf.Sin( (Time.time + PhaseDifference) * 2f * Mathf.PI / Period);
        ThisTransform.localPosition = _startLocalPosition + MaxLocalPositionOffset * scale;
    }

}
