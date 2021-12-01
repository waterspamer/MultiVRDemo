using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HidingLable : MonoBehaviour {

    public float Lifetime = 5f;
    private float _t;
    public Text Text;

    private Color StartColor;

    void Start(){
        StartColor = Text.color;
    }

    void Update() {

        _t -= Time.deltaTime;
        if(_t < 1f){
            Text.color = new Color(StartColor.r, StartColor.g, StartColor.b, _t);
            if(_t <=0){
                Text.enabled = false;
                this.enabled = false;
            }
        }
        
    }

    public void Show(){
        Text.enabled = true;
        this.enabled = true;
        _t = Lifetime;
        Text.color = new Color(StartColor.r, StartColor.g, StartColor.b, 1f);
    }

}
