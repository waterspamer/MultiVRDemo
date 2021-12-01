using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowerBehaviourChangeMaterial : HowerBehaviour
{
    public Renderer[] Renderers;
    public List<Material[]> StartMaterials = new List<Material[]>();
    public Material Howeredmaterial;

    public override void Init() {
        base.Init();
        for (int i = 0; i < Renderers.Length; i++) {
            StartMaterials.Add(Renderers[i].materials);
        }
    }

    public override void OnHower() {
        base.OnHower();
        
        for (int i = 0; i < Renderers.Length; i++) {
            Material[] newMaterials = new Material[Renderers[i].materials.Length];
            for (int m = 0; m < Renderers[i].materials.Length; m++) {
                newMaterials[m] = Howeredmaterial;
            }
            Renderers[i].materials = newMaterials;
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
