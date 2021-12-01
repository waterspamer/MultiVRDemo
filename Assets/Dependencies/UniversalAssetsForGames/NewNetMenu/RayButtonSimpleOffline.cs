using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RayButtonSimpleOffline : RayButtonOffline
{
    public UnityEvent EventOnPress;

    [ContextMenu("Press")]
    public void Press()
    {
        EventOnPress.Invoke();
    }

    public override void OnPress(DragRay dragRay)
    {
        EventOnPress.Invoke();
    }
}