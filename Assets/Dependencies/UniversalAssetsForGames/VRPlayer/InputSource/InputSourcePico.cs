using System.Collections;
using System.Collections.Generic;
using Unity.XR.PXR;
using UnityEngine;

public class InputSourcePico : InputSource {
    public int HandId = 1;

    public override InputResult CheckInput()
    {

        /*
        
#if UNITY_ANDROID
        if (PXR_Input.Controller.UPvr_GetKeyDown(HandId, Pvr_KeyCode.A)) {
            return InputResult.Press;
        }
        if (PXR_Input.Controller.UPvr_GetKeyUp(HandId, Pvr_KeyCode.A)) {
            return InputResult.Release;
        }
#endif
        return InputResult.None;
    }
    */
        return InputResult.None;
    }
}
