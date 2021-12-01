using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Antilatency.SDK;

public class InputSourceBracer : InputSource {

    public Bracer Bracer;

    public override InputResult CheckInput() {
        return InputResult.None;
    }

    public override void Init(MultiplatformInput multiplatformInput) {

        base.Init(multiplatformInput);
        if (Bracer) {
            
            Bracer.BracerTouch.AddListener(BracerTouch);
        }
    }

    public void BracerTouch(BracerTouchState bracerTouchState) {
       
        if (bracerTouchState == BracerTouchState.Pressed) {
            
            MultiplatformInput.Press();
        }
        if (bracerTouchState == BracerTouchState.Released) {
            MultiplatformInput.Release();
        }
    }

}
