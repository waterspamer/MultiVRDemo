using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadIcon : MonoBehaviour
{

    private float _t;
    public float Period;

    void Update() {
        _t += Time.deltaTime;
        if(_t > Period) {
            _t = 0f;
            transform.Rotate(0f,0f,-30f);
        }
        
    }

}
