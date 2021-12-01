using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface  IRayButton {

    void OnUnpress(DragRay dragRay);
    void OnPress(DragRay dragRay);
    void OnHower(DragRay dragRay);
    void OnUnhower(DragRay dragRay);
    void WhenPressed(DragRay dragRay);
    bool GetStopRaycusting();

}
