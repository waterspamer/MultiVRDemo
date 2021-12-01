using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Antilatency.DeviceNetwork;

namespace Antilatency.SDK {
    /// <summary>
    /// Bracer basic implementation.
    /// </summary>
    public class BracerAnyTag : Bracer {

        [SerializeField]
        private GameObject _model;

        private void Awake()
        {
            if (_model != null)
            {
                _model.SetActive(CurrentState == BracerState.Connected);
                BracerStateChanged.AddListener(ShowHideModel);
            }

        }

        protected override NodeHandle GetAvailableBracerNode() {
            var result = new NodeHandle();

            var network = GetNativeNetwork();
            if (network == null) {
                return result;
            }

            using (var cotaskConstructor = _bracerLibrary.getCotaskConstructor()) {
                if (cotaskConstructor == null) {
                    return result;
                }

                var nodes = cotaskConstructor.findSupportedNodes(network).Where(v =>
                        //network.nodeGetStringProperty(v, "Tag") == BracerTag &&
                        network.nodeGetStatus(v) == Antilatency.DeviceNetwork.NodeStatus.Idle
                    ).ToList();

                if (nodes.Count > 0) {
                    result = nodes[0];
                }

                return result;
            }
        }

        private void ShowHideModel(BracerState state){
            _model.SetActive(state == BracerState.Connected);
        }
        
    }
}