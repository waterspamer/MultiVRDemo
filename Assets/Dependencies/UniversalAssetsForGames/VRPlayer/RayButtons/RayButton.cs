using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public  class RayButton : NetworkBehaviour, IRayButton { // abstract
    
    public bool StopRaycusting = true;
    public HowerBehaviour[] HowerBehaviours;
    public DragRay CurrentDragRay;

    public bool GetStopRaycusting() {
        return StopRaycusting;
    }

    protected virtual void Start() {
        for (int i = 0; i < HowerBehaviours.Length; i++) {
            HowerBehaviours[i].Init();
        }
    }
    
    public virtual void OnHower(DragRay dragRay) {
        for (int i = 0; i < HowerBehaviours.Length; i++) {
            HowerBehaviours[i].OnHower();
        }
    }

    public virtual void OnUnhower(DragRay dragRay) {
        for (int i = 0; i < HowerBehaviours.Length; i++) {
            HowerBehaviours[i].OnUnhower();
        }
    }

    // TEST --------------------------------------------------------------------
    private void OnDestroy() {
        if (CurrentDragRay) {
            CurrentDragRay.HoweredRayButton = null;
            CurrentDragRay.CurrentRayButton = null;
        }
    }

    public virtual void OnPress(DragRay dragRay) {
        CurrentDragRay = dragRay;
    }
    public InspectorButton _TestOnPress;
    public void TestOnPress() {
        OnPress(null);
    }


    public virtual void OnUnpress(DragRay dragRay) {
        CurrentDragRay = null;
    }

    public virtual void WhenPressed(DragRay dragRay) {
    }

}
