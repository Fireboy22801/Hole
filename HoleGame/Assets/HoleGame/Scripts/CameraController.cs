using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float distanceStep;

    public void IncreaseDistance()
    {
        CinemachineVirtualCamera virtualCamera = GetComponent<CinemachineVirtualCamera>();
        CinemachineTransposer transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        transposer.m_FollowOffset.y += distanceStep;
    }
}
