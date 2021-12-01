using UnityEngine;

public class LookAtCameraXz : MonoBehaviour
{
    private Transform _transform;
    public Transform CametaTransform;

    void Start() {
        _transform = transform;
    }

    void LateUpdate() {
        if (CametaTransform) {
            Vector3 fromTo = CametaTransform.position - transform.position;
            Vector3 fromToXz = new Vector3(fromTo.x, 0f, fromTo.z);
            Quaternion rot = Quaternion.LookRotation(fromToXz, Vector3.up);
            _transform.rotation = rot;
        } else {
            CametaTransform = Camera.main.transform;
        }
    }

}
