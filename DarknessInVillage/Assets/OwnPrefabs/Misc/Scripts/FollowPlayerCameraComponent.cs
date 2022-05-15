using UnityEngine;

public class FollowPlayerCameraComponent : MonoBehaviour
{
    [SerializeField] private Transform _targetForFollow;
    [SerializeField] private float _smoothSpeedCamera;
    [SerializeField] private Vector3 _cameraOffset;

    private void LateUpdate()
    {
        Vector3 desiredPosition = _targetForFollow.position + _cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeedCamera);
        transform.position = smoothedPosition;
    }
}
