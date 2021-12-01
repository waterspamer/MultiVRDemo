using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HowerBehaviourHighlight : HowerBehaviour {

    public Renderer[] Renderers;
    public Color HighlightEmissionColor = new Color32(60, 40, 0, 255);
    public List<Material[]> StartMaterials = new List<Material[]>();

    public override void Init() {
        base.Init();        
        for (int i = 0; i < Renderers.Length; i++) {
            StartMaterials.Add(Renderers[i].sharedMaterials);
        }
    }

    public override void OnHower() {
        base.OnHower();
        for (int i = 0; i < Renderers.Length; i++) {
            for (int m = 0; m < Renderers[i].sharedMaterials.Length; m++) {
                Renderers[i].materials[m].SetColor("_EmissionColor", HighlightEmissionColor);
            }
        }
    }

    public override void OnUnhower() {
        base.OnUnhower();
        int listIndex = 0;
        for (int i = 0; i < Renderers.Length; i++) {
            Renderers[i].sharedMaterials = StartMaterials[i];
        }
    }


}
