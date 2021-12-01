using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetGameManager : MonoBehaviour {

    private static NetGameManager _instance;
    public static NetGameManager Instance {
        get {
            return _instance;
        }
    }

    void Awake() {
        if (_instance == null) {
            _instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public int CurrentPlayerNetId;



}
