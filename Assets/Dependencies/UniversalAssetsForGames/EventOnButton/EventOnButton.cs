using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnButton : MonoBehaviour {

    public UnityEvent OnButtonPressed;

    public void WhenPress() {
        OnButtonPressed.Invoke();
    }

}
