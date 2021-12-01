using UnityEngine;

public class RayButtonCollider : MonoBehaviour {

    public RayButton RayButton;
    public RayButtonOffline RayButtonOffline;

    public IRayButton IRayButton;

    public bool DontHighlightAsMoveingObjectPart;

    void Start() {
        if (RayButton) {
            IRayButton = RayButton;
        } else if (RayButtonOffline) {
            IRayButton = RayButtonOffline;
            
        }
    }

}
