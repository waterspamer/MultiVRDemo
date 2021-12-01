using System.Collections;
using System.Collections.Generic;
using Antilatency.DeviceNetwork;
using UnityEngine;
using System.Linq;

namespace Antilatency.SDK {
    /// <summary>
    /// The sample component that starts the tracking task on an Alt connected to a socket (bracer, tag) tagged with <paramref name="Tag"/>.
    /// </summary>
    public class AltTrackingAnyTag : AltTrackingTag {

        protected override NodeHandle GetAvailableTrackingNode() {
            var nativeNetwork = GetNativeNetwork();
            if (nativeNetwork == null) {
                return new NodeHandle();
            }

            using (var cotaskConstructor = _trackingLibrary.createTrackingCotaskConstructor()) {
                var nodes = cotaskConstructor.findSupportedNodes(nativeNetwork).Where(v =>
                        //nativeNetwork.nodeGetStringProperty(nativeNetwork.nodeGetParent(v), "Tag") == socketTag &&
                        nativeNetwork.nodeGetParent(nativeNetwork.nodeGetParent(v)) != Antilatency.DeviceNetwork.NodeHandle.Null &&
                        nativeNetwork.nodeGetStatus(v) == NodeStatus.Idle
                        ).ToArray();

                if (nodes.Length == 0) {
                    return new NodeHandle();
                }
                return nodes[0];
            }
        }

        /// <returns>The pose that is created from PlacementOffset and PlacementRotation.</returns>
        protected override Pose GetPlacement() {
            return new Pose(PlacementOffset, Quaternion.Euler(PlacementRotation));
        }

        /// <summary>
        /// Apply tracking data to a component's GameObject transform.
        /// </summary>
        protected override void Update() {
            base.Update();

            Antilatency.Alt.Tracking.State trackingState;

            if (!GetTrackingState(out trackingState)) {
                return;
            }

            transform.localPosition = trackingState.pose.position;
            transform.localRotation = trackingState.pose.rotation;
        }
        
    }
}
