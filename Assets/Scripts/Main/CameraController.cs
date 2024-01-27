using UnityEngine;
using Cinemachine;

public class CameraController : Singleton<CameraController>
{
    private CinemachineVirtualCamera _virtualCamera;

    protected override void Awake()
    {
        base.Awake();
        _virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
    }

    public void SetTarget(Transform target)
    {
        _virtualCamera.Follow = target;
        _virtualCamera.LookAt = target;
    }
}
