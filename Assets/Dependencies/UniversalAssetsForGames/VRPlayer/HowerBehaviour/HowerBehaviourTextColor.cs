using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowerBehaviourTextColor : HowerBehaviour
{
    private Color StartColor;
    public Text Text;
    public Color HowerColor;

    public override void Init() {
        base.Init();        
        StartColor = Text.color;
    }

    public override void OnHower() {
        base.OnHower();
        Text.color = HowerColor;
    }

    public override void OnUnhower() {
        base.OnUnhower();
        Text.color = StartColor;
    }

}
