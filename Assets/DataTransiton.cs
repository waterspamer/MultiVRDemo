using System.Collections;
using System.Collections.Generic;
using Antilatency.SDK;
using UnityEngine;

public class DataTransiton : MonoBehaviour
{

    public AltTrackingDirect a;

    public Transform networkObject;
    
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (a && networkObject)
            networkObject.SetPositionAndRotation(a.transform.position, a.transform.rotation);
    }
}
