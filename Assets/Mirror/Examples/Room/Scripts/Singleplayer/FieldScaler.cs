using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Antilatency.SDK;
using UnityEngine;

public class FieldScaler : MonoBehaviour
{
    public GameObject playZone;
    public AltEnvironment altEnvironment;

    // Start is called before the first frame update
    void Start()
    {
        ScaleZone();
    }

    public void ScaleZone()
    {
        var markers = altEnvironment.GetEnvironment().getMarkers();

        var maxX = markers.Max((v=> v.x));
        var minX = markers.Min((v=> v.x));
        
        var maxZ = markers.Max((v=> v.z));
        var minZ = markers.Min((v=> v.z));
        
        var difX = maxX - minX + .54f;
        var difZ = maxZ - minZ+ .54f;
        playZone.transform.localScale = new Vector3(difX, difZ, 1 );

        var aspectRatio = difX / difZ;
        
        playZone.GetComponent<MeshRenderer>().material.SetTextureScale(
            "_MainTex", new Vector2(1, 1 / aspectRatio));


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
