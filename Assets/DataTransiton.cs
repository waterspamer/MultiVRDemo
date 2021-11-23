using System;
using System.Collections;
using System.Collections.Generic;
using Antilatency.SDK;
using UnityEngine;

public class DataTransiton : MonoBehaviour
{

    public AltTracking a;

    public Transform networkObject;


    IEnumerator Delay(Action act)
    {
        yield return new WaitForSeconds(2f);
        act?.Invoke();
    }

    public void Start()
    {
        StartCoroutine(Delay(()=>networkObject = GameObject.Find("GamePlayer(Clone)").transform));

    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (a && networkObject)
            networkObject.SetPositionAndRotation(a.transform.position, a.transform.rotation);
    }
}
