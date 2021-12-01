using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsClock : MonoBehaviour {

    private float _t;
    [SerializeField] private int _rps = 10;
    [SerializeField] private Transform _arrowCenterTramsform;

	void Update () {
	    _t += Time.unscaledDeltaTime;
	    _arrowCenterTramsform.localEulerAngles = new Vector3(0f, _t * 360f * _rps, 0f);
    }
    
}
