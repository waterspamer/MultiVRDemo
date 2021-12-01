using System.Collections;
using System.Collections.Generic;
using Unity.XR.PXR;
using UnityEngine;

public class Pvr_ActiveOnControllerState : MonoBehaviour
{
    public List<GameObject> Objects;
    public int HandId = 0;

    private bool _state = true;

    private void LateUpdate()
    {
        
    }
}
