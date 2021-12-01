using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Antilatency.SDK;
using UnityEngine;

public class FieldScaler : MonoBehaviour
{
    public GameObject playZone;
    public AltEnvironment altEnvironment;

    public List<GameObject> gateSet;

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

        
        
        if (difX < difZ)
        {
            gateSet[0].SetActive(false);
            gateSet[1].SetActive(false);
            foreach (var gate in gateSet)
            {
                gate.transform.localScale =new Vector3(gate.transform.localScale.x, difZ, gate.transform.localScale.z );
            }
            
        }
        else
        {
            gateSet[2].SetActive(false);
            gateSet[3].SetActive(false);
            foreach (var gate in gateSet)
            {
                gate.transform.localScale =new Vector3(gate.transform.localScale.x, difX, gate.transform.localScale.z);
            }
        }
            

        
        playZone.GetComponent<MeshRenderer>().material.SetTextureScale(
            "_MainTex", new Vector2(1, 1 / aspectRatio));


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
