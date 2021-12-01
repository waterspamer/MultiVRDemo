/*
using System.Collections;
using System.Collections.Generic;
using Antilatency.SDK;
using UnityEngine;
using Antilatency.DeviceNetwork;

public class OnUnfocusApplicationBehaviour : MonoBehaviour {

    private bool _wasUnfocused = false;
    void OnApplicationFocus(bool value) {

        DeviceNetwork[] deviceNetworks = FindObjectsOfType<DeviceNetwork>();
        for(int i = 0; i < deviceNetworks.Length; i++) {
            if(!value) {
                deviceNetworks[i].OnDestroy();
            } else if (_wasUnfocused) {
                deviceNetworks[i].Init();
            }
        }

        AltTracking[] altTrackings = FindObjectsOfType<AltTracking>();
        for(int i = 0; i < altTrackings.Length; i++) {
            if(!value) {
                altTrackings[i].OnDestroy();
            } else if (_wasUnfocused) {
                altTrackings[i].Init();
            }
        }

        if(!value) {
            _wasUnfocused = true;
        } else if (_wasUnfocused) {
            _wasUnfocused = false;
        }

    }
    
}
*/