using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayInEditorMode : MonoBehaviour {
    
    public Transform HandTransform;
    public Transform HandParentTransform;

    public GameObject TestCameraGameObject;
    public GameObject VRCameraGameObject;

    

    void Start() {

#if UNITY_EDITOR || UNITY_STANDALONE_WIN

        if (HandTransform) {
            HandTransform.SetParent(HandParentTransform);
            HandTransform.localPosition = Vector3.zero;
            HandTransform.localRotation = Quaternion.identity;
        }
        
        if (TestCameraGameObject) {
            TestCameraGameObject.SetActive(true);
        }

        if (VRCameraGameObject) {
            VRCameraGameObject.SetActive(false);
        }
        
#endif

    }
    

}
