using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayButtonOffline : MonoBehaviour, IRayButton
{

    public HowerBehaviour[] HowerBehaviours;
    

    protected virtual void Start() {
        for (int i = 0; i < HowerBehaviours.Length; i++) {
            HowerBehaviours[i].Init();
        }
    }
    
    public virtual void OnHower(DragRay dragRay) {
        Debug.Log("OnHower");
        for (int i = 0; i < HowerBehaviours.Length; i++) {
            HowerBehaviours[i].OnHower();
        }
    }

    public virtual void OnUnhower(DragRay dragRay) {
        for (int i = 0; i < HowerBehaviours.Length; i++) {
            HowerBehaviours[i].OnUnhower();
        }
    }

    public virtual void OnPress(DragRay dragRay) {
    }
    public virtual void OnUnpress(DragRay dragRay) {

    }

    public virtual void WhenPressed(DragRay dragRay){

    }

    public bool GetStopRaycusting(){
        return true;
    }

}
