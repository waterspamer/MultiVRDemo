using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowerBehaviourScale : HowerBehaviour {

    private Vector3 StartScale;
    public Transform TransformToScale;
    public float ScaleMultiplier = 1.15f;

    public override void Init() {
        base.Init();
        if (TransformToScale == null) {
            TransformToScale = transform;
        }
        StartScale = TransformToScale.localScale;
    }

    public override void OnHower() {
        base.OnHower();
        TransformToScale.localScale = StartScale * ScaleMultiplier;
    }

    public override void OnUnhower() {
        base.OnUnhower();
        TransformToScale.localScale = StartScale;
    }

}
