using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnKey : MonoBehaviour {
    
    public KeyCode KeyCode;
    public UnityEvent UnityEvent;

    void Update() {
        if (Input.GetKeyDown(KeyCode)) {
            UnityEvent.Invoke();
        }
    }

}
