using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSourceOculus : InputSource {

    public override InputResult CheckInput() {
#if oculus
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) {
            return InputResult.Press;
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)) {
            return InputResult.Release;
        }
        return InputResult.None;
#endif
        return InputResult.None;
    }

}
