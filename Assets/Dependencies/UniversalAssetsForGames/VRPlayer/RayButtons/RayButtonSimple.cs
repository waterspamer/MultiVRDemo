using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RayButtonSimple : RayButton {

    public UnityEvent EventOnPress;

    public override void OnPress(DragRay dragRay) {
        EventOnPress.Invoke();
    }
    
    

}
