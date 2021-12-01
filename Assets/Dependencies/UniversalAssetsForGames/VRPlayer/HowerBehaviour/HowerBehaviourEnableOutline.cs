using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HowerBehaviourEnableOutline : HowerBehaviour
{
    public Outline Outline;
    public override void OnHower() {
        base.OnHower();
        Outline.enabled = true;
    }

    public override void OnUnhower() {
        base.OnUnhower();
        Outline.enabled = false;
    }

}
