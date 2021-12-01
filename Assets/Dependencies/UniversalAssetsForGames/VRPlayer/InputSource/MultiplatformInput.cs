using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultiplatformInput : MonoBehaviour {

    public bool IsPressed;

    public UnityEvent EventOnPress;
    public UnityEvent EventOnRelease;

    public List<InputSource> InputSourceList;

    public void Press() {
        IsPressed = true;
        EventOnPress.Invoke();
    }

    public void Release() {
        IsPressed = false;
        EventOnRelease.Invoke();
    }

    void Start() {
        for (int i = 0; i < InputSourceList.Count; i++) {
            InputSourceList[i].Init(this);
        }
    }

    void Update() {
        for (int i = 0; i < InputSourceList.Count; i++) {
            InputResult inputResult = InputSourceList[i].CheckInput();
            if (inputResult == InputResult.Press) {
                Press();
            } else if (inputResult == InputResult.Release) {
                Release();
            }
        }
    }

}
