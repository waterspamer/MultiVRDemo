using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowerBehaviourShowObject : HowerBehaviour {
    
    public GameObject ObjectToShow;

    public override void Init() {
        base.Init();
        ObjectToShow.SetActive(false);
    }

    public override void OnHower() {
        base.OnHower();
        ObjectToShow.SetActive(true);
    }

    public override void OnUnhower() {
        base.OnUnhower();
        ObjectToShow.SetActive(false);
    }


}
