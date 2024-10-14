using System;
using UnityEngine.XR;
using UnityEngine;

public class SurfaceTracking : MonoBehaviour
{
    [SerializeField] private GameObject _virtualObject;
    private OVRPassthroughLayer _passthroughLayer;

    private void Start()
    {
        _passthroughLayer = FindObjectOfType<OVRPassthroughLayer>();
        if (_passthroughLayer != null)
        {
            _passthroughLayer.hidden = false;
        }
        
        XRSettings.enabled = true;
    }

    private void Update()
    {
        
    }
}
