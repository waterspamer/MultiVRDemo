using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScale : MonoBehaviour {

    public float SizeMult;
    public Material Material;

    public InspectorButton _UpdateScale;

    public Transform BoxTransform;

    public void UpdateScale() {
        Material.SetTextureScale("_MainTex", new Vector2(BoxTransform.localScale.x * SizeMult, BoxTransform.localScale.z * SizeMult));
    }

}
