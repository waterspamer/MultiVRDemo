using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputResult {
    Press,
    Release,
    None
}

public abstract class InputSource : MonoBehaviour {

    [HideInInspector]
    public MultiplatformInput MultiplatformInput;

    public virtual void Init(MultiplatformInput multiplatformInput) {
        MultiplatformInput = multiplatformInput;
    }

    public abstract InputResult CheckInput();

}
