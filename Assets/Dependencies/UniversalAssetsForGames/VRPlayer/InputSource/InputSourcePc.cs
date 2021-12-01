using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSourcePc : InputSource {

    public override InputResult CheckInput() {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Joystick1Button0)) {
            return InputResult.Press;
        }
        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Joystick1Button0)) {
            return InputResult.Release;
        }
        return InputResult.None;
    }

}
