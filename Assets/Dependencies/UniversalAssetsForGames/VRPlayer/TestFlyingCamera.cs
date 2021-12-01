using UnityEngine;

public class TestFlyingCamera : MonoBehaviour {
    
    //[SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _mouseSensitivity = .5f;
    
    private Vector3 _mouseStartPos;
    private Vector3 _mouseDelta;

    private float _startRotY;
    private float _startRotX;

    private Transform _thisTransform;

    public float MoveSpeed = 1f;

    public bool RotateWithMouseButton = true;

    void Awake() {
        _thisTransform = transform;
    }

#if UNITY_EDITOR || UNITY_STANDALONE
    void Update () {
        Move();
        Rotate();
    }
#endif

    private void Move() {
        float speed = Time.deltaTime * MoveSpeed;
        if (Input.GetKey(KeyCode.LeftShift)) speed *= 4f;
        if (Input.GetKey(KeyCode.W)) _thisTransform.Translate(Vector3.forward * speed, transform);
        if (Input.GetKey(KeyCode.S)) _thisTransform.Translate(-Vector3.forward * speed, transform);
        if (Input.GetKey(KeyCode.A)) _thisTransform.Translate(-Vector3.right * speed, transform);
        if (Input.GetKey(KeyCode.D)) _thisTransform.Translate(Vector3.right * speed, transform);
        if (Input.GetKey(KeyCode.E)) _thisTransform.Translate(Vector3.up * speed, transform);
        if (Input.GetKey(KeyCode.C)) _thisTransform.Translate(-Vector3.up * speed, transform);
    }

    private Vector3 _mousePreveousePos;
    
    void Rotate() {
        Vector3 _mouseDelta = Vector3.zero;

        if (Input.GetMouseButtonDown(1)) {
            _mousePreveousePos = Input.mousePosition;
        }

        
        if (Input.GetMouseButton(1) || !RotateWithMouseButton) {
            _mouseDelta = Input.mousePosition - _mousePreveousePos;
            _mousePreveousePos = Input.mousePosition;

            _thisTransform.Rotate(-_thisTransform.right, _mouseDelta.y * _mouseSensitivity, Space.World);
            _thisTransform.Rotate(Vector3.up, _mouseDelta.x * _mouseSensitivity, Space.World);
        }
    }

}
