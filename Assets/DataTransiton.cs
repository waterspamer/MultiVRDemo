using System;
using System.Collections;
using System.Collections.Generic;
using Antilatency.SDK;
using Mirror.Examples.Room.Scripts;
using UnityEngine;

public class DataTransiton : MonoBehaviour
{
    [Header("Rig presets")]
    public AltTracking a;

    public Transform camera;

    public AltTracking leftHand;
    
    public AltTracking rightHand;

    public AltTracking leftFoot;

    public AltTracking rightFoot;


    
    
    [Header("Network Visualizing presets")]
    public Transform networkObject;

    public string leftHandName;
    
    public string rightHandName;

    
    public string leftFootName;

    public string rightFootName;

    public string vrHeadName;




    private Transform _lHand;
    private Transform _rHand;
    private Transform _lFoot;
    private Transform _rFoot;

    private Transform _vrHead;


    public int index;
    IEnumerator Delay(Action act)
    {
        yield return new WaitForSeconds(2f);
        act?.Invoke();
    }

    public void Start()
    {
        StartCoroutine(Delay(()=>networkObject = GetRefGameObject().transform));
    }

    
    public Transform GetRefGameObject()
    {
        var list = new List<GameObject>();
        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if(gameObj.name == "GamePlayer(Clone)")
            {
                list.Add(gameObj);
            }
        }

        index = Ternar.isClient ? 0 : 1;

        var obj = list[index].transform;
        
        _lHand = obj.Find(leftHandName);
        _rHand = obj.Find(rightHandName);
        _lFoot = obj.Find(leftFootName);
        _rFoot = obj.Find(rightFootName);

        _vrHead = obj.Find(vrHeadName);

        return list[index].transform;
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (a && networkObject)
        {
            networkObject.SetPositionAndRotation(a.transform.position, a.transform.rotation);
            
            _lHand?.SetPositionAndRotation(leftHand.transform.position, leftHand.transform.rotation);
            _rHand?.SetPositionAndRotation(rightHand.transform.position, rightHand.transform.rotation);
            _lFoot?.SetPositionAndRotation(leftFoot.transform.position, leftFoot.transform.rotation);
            _rFoot?.SetPositionAndRotation(rightFoot.transform.position, rightFoot.transform.rotation);
            
            _vrHead?.SetPositionAndRotation(camera.transform.position, camera.transform.rotation);
            
        }
            
    }
}
