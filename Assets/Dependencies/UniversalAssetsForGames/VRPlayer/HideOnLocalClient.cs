using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnLocalClient : MonoBehaviour
{
    [SerializeField]
    private ClientPlayer _player;
    [SerializeField]
    private bool _invertState = false;

    private void Start()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>(true);
        foreach (Renderer r in renderers)
        {
            r.enabled = _player.isLocalPlayer == _invertState;
        }
    }
}
