using System.Collections;
using System.Collections.Generic;
using Antilatency.SDK;
using UnityEngine;

public class FindBracer : MonoBehaviour {

    public InputSourceBracer InputSourceBracer;
    public string StringToFallow;

    void Start() {
        
        Debug.Log("FindTarget: " + FollowingByTagTargetCollection.Instance.FindTaget(StringToFallow));
        Debug.Log("GetBracer? : " + FollowingByTagTargetCollection.Instance.FindTaget(StringToFallow)?.GetComponent<Bracer>());
        Debug.Log(StringToFallow);


        FollowingByTagTargetCollection.Instance.FindTaget(StringToFallow)?.GetComponent<Bracer>()?.BracerTouch.AddListener(InputSourceBracer.BracerTouch);
    }

    public void RemoveListener() {
        return;
        FollowingByTagTargetCollection.Instance.FindTaget(StringToFallow)?.GetComponent<Bracer>()?.BracerTouch.RemoveListener(InputSourceBracer.BracerTouch);
    }

}
