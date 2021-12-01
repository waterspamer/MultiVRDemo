using UnityEngine;

public class LookAtCamera : MonoBehaviour {

    private Transform _transform;
    public Transform CametaTransform;

    void Start() {
        _transform = transform;
    }

    void LateUpdate() {
        if (CametaTransform) {
            _transform.LookAt(CametaTransform.position);
        }
        else {
            CametaTransform = Camera.main.transform;
        }
    }

}
