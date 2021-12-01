using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingByTagTargetCollection {

    private List<FollowingByTagTarget> _followingByTagTargetList = new List<FollowingByTagTarget>();

    private static FollowingByTagTargetCollection _instance;
    private static bool _instanceSet = false;
    public static FollowingByTagTargetCollection Instance {
        get {
            if (!_instanceSet)
            {
                _instance = new FollowingByTagTargetCollection();
                _instanceSet = true;
            }
            return _instance;
        }
    }

    private FollowingByTagTargetCollection()
    {
    }

    public static void ClearInstance()
    {
        _instance = null;
        _instanceSet = false;
    }

    public delegate void TargetsUpdateEvent();
    public TargetsUpdateEvent OnTargetsUpdate;

    public void AddTarget(FollowingByTagTarget newTarget)
    {
        if (newTarget == null || _followingByTagTargetList.Contains(newTarget))
        {
            return;
        }
        //If other targets with the same tag exist, place the new one according to priority
        int id = 0;
        foreach (FollowingByTagTarget target in _followingByTagTargetList)
        {
            if (target.Tag == newTarget.Tag)
            {
                if (target.Priority < newTarget.Priority) {
                    _followingByTagTargetList.Insert(id, newTarget);
                    if (OnTargetsUpdate != null)
                    {
                        OnTargetsUpdate();
                    }
                    return;
                }
            }
            id++;
        }
        _followingByTagTargetList.Add(newTarget);
    }

    public void RemoveTarget(FollowingByTagTarget target)
    {
        _followingByTagTargetList.Remove(target);
        if (OnTargetsUpdate != null)
        {
            OnTargetsUpdate();
        }
    }

    public FollowingByTagTarget FindTaget (string tag) {     

        for (int i = 0; i < _followingByTagTargetList.Count; i++) {
           
            if (_followingByTagTargetList[i].Tag == tag) {
                return _followingByTagTargetList[i];
            }
        }
        return null;
    }
}

public class FollowingByTagTarget : MonoBehaviour {
    public int Priority = 0;
    public string Tag;
    void OnEnable()
    {
        FollowingByTagTargetCollection.Instance.AddTarget(this);
    }
    void OnDisable()
    {
        FollowingByTagTargetCollection.Instance.RemoveTarget(this);
    }

}
