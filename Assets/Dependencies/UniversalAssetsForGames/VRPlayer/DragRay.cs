using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRay : MonoBehaviour {

    public Transform ParentPoint;
    private float _dist;
    public LayerMask LayerMask;
    public Transform RayStart;

    public IRayButton HoweredRayButton;
    public IRayButton CurrentRayButton;
    public AudioSource PickAudioSource;

    public MultiplatformInput MultiplatformInput;
    public float MaxRayDistance = 1f;

    public StretchingLine StretchingLine;

    public Vector3 GetRayPointPosition() {
        return GetRay().GetPoint(_dist);
    }

    void Start() {
        MultiplatformInput.EventOnPress.AddListener(InputDown);
        MultiplatformInput.EventOnRelease.AddListener(InputUp);
    }

    void LateUpdate() {

        /*
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
        Gizmos.DrawRay(transform.position, direction);
        */
        ParentPoint.transform.Rotate(0f, 0f, Input.mouseScrollDelta.y * 10f);

        RaycastHit hit;

        if (Physics.Raycast(GetRay(), out hit, MaxRayDistance, LayerMask, QueryTriggerInteraction.Ignore)) {

            if (CurrentRayButton == null || !CurrentRayButton.GetStopRaycusting()) {
                HoweringRayButton(hit.collider);
            }

            if (CurrentRayButton != null) {
                if (!CurrentRayButton.GetStopRaycusting()) {
                    if (hit.collider.GetComponent<RayButtonCollider>()) {
                        _dist = hit.distance;
                        SetParentPointPositionLocalClient(hit.point);
                    }
                }
            } else {
                _dist = hit.distance;
                SetParentPointPositionLocalClient(hit.point);
            }


        } else {
            if ((HoweredRayButton as RayButton) != null || (HoweredRayButton as RayButtonOffline) != null) {
                HoweredRayButton.OnUnhower(this);
                HoweredRayButton = null;
            }
            if (CurrentRayButton == null) {
                SetParentPointPositionLocalClient(GetRay().GetPoint(MaxRayDistance));
            }
        }

        //Debug.Log(HoweredRayButton);

        if (CurrentRayButton != null) {
            CurrentRayButton.WhenPressed(this);
        }



    }

    public void InputDown() {
        //Debug.Log("InputDown");
        if (CurrentRayButton != null) return;
        if (HoweredRayButton != null) {
            CurrentRayButton = HoweredRayButton;
            CurrentRayButton.OnPress(this);
        }
        if (PickAudioSource) {
            PickAudioSource.pitch = .6f;
            PickAudioSource.Play();
        }
    }

    public void InputUp() {
        if (CurrentRayButton != null) {
            CurrentRayButton.OnUnpress(this);
            CurrentRayButton = null;
        }
        if (PickAudioSource) {
            PickAudioSource.pitch = .3f;
            PickAudioSource.Play();
        }
    }


    Ray GetRay() {
        return new Ray(transform.position, transform.forward);
    }


    void HoweringRayButton(Collider collider) {

        IRayButton rayButton = null;
        RayButtonCollider rayButtonCollider = collider.GetComponent<RayButtonCollider>();

        if (rayButtonCollider) {
            rayButton = rayButtonCollider.IRayButton;
        }

        if (rayButton != null) {
            if (rayButton != HoweredRayButton) {
                if ((HoweredRayButton as RayButton) != null || (HoweredRayButton as RayButtonOffline) != null) {
                    HoweredRayButton.OnUnhower(this);
                }
                HoweredRayButton = rayButton;
                rayButton.OnHower(this);
            }
        } else {
            if ((HoweredRayButton as RayButton) != null || (HoweredRayButton as RayButtonOffline) != null) {
                HoweredRayButton.OnUnhower(this);
                HoweredRayButton = null;
            }
        }

    }
    
    void SetParentPointPositionLocalClient(Vector3 pos) {
        SetParentPointPosition(pos);
        // почему-то при первом апдейте ExecuteByClient.Current не определен
        ExecuteByClientBase.Current?.CmdSetRay(pos, ExecuteByClientBase.Current.netId);
    }

    public void SetParentPointPosition(Vector3 pos) {
        ParentPoint.position = pos;
        RayStart.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(pos, RayStart.position));
    }

}
