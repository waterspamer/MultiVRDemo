using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayButtonMoveing : RayButton {

    protected bool _isGrabbed;

    public override void OnPress(DragRay dragRay) {
        _isGrabbed = true;
        transform.SetParent(dragRay.ParentPoint);
    }

    public override void OnUnpress(DragRay dragRay) {
        _isGrabbed = false;
        transform.SetParent(null);
    }

}
