using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Antilatency.SDK;

public class RayTarget : MonoBehaviour {

	public string StringToFallowBracer;
	public string StringToFallowController;

	public Transform TargetBracer;
	public Transform TargetOculusController;

	

	void Start() {
	    AltTrackingTagWithPublicTrackingState AltTrackingBracer = FollowingByTagTargetCollection.Instance.FindTaget(StringToFallowBracer).GetComponent<AltTrackingTagWithPublicTrackingState>();
		AltTrackingBracer.TrackingTaskStateChanged.AddListener(BracerStateChanged);
		
		TargetBracer = FollowingByTagTargetCollection.Instance.FindTaget(StringToFallowBracer).transform;
		TargetOculusController = FollowingByTagTargetCollection.Instance.FindTaget(StringToFallowController).transform;

		if (AltTrackingBracer.TrackingState) {
			BracerStateChanged(true);
		} else {
			BracerStateChanged(false);
		}
	}

	public void BracerStateChanged(bool value) {
		if (value) {
			transform.SetParent(TargetBracer);
		} else {
			transform.SetParent(TargetOculusController);
		}
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
	}

}
