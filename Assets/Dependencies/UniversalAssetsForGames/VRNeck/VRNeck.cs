using System.Linq;
using UnityEngine;


public static class QuaternionExtension {
    public static Quaternion ToQuaternion(this Vector3 value) {
        Quaternion result = Quaternion.identity;
        float angle = value.magnitude;
        float halfAngle = 0.5f * angle;
        value *= 1f / angle;

        if (halfAngle > 0) {
            float sin = Mathf.Sin(halfAngle);
            result.x = value.x * sin;
            result.y = value.y * sin;
            result.z = value.z * sin;
            result.w = Mathf.Cos(halfAngle);
        }

        return result;
    }

    public static Vector3 ToAngularVelocity(this Quaternion value) {
        Vector3 axis = new Vector3(value.x, value.y, value.z);
        axis.Normalize();
        return axis * 2 * Mathf.Acos(value.w);
    }

    /*
    public static void PositiveW(this ref Quaternion value) {
        var s = value.w < 0?-1:1;
        value.x *= s;
        value.y *= s;
        value.z *= s;
        value.w *= s;
    }
    */

}

[ExecuteInEditMode]
public class VRNeck : MonoBehaviour
{
    public Transform[] bones;
    //private Quaternion[] initialRotations;

    public float multiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        //initialRotations = bones.Select(x => x.localRotation).ToArray();
    }

    


    // Update is called once per frame
    void Update()
    {
        var rotation = Quaternion.FromToRotation(Vector3.up, transform.InverseTransformDirection(Vector3.up));
        //rotation.PositiveW();
        rotation = PositiveW(rotation);
        var rotationVector = rotation.ToAngularVelocity();
        rotationVector *= multiplier / bones.Length;
        var boneAdditionalRotation = rotationVector.ToQuaternion();
        for (int i = 0; i < bones.Length; i++) {
            bones[i].localRotation = /*initialRotations[i] **/ boneAdditionalRotation;
        }
    }



    public static Quaternion PositiveW(Quaternion value) {
        var s = value.w < 0 ? -1 : 1;
        value.x *= s;
        value.y *= s;
        value.z *= s;
        value.w *= s;
        return value;
    }

}
