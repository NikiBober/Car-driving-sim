using UnityEngine;
using UnityEngine.InputSystem;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _distance = 5f;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = _targetTransform.position;
    }

    private void OnMove(InputValue movementValue)
    {
        float inputX = movementValue.Get<Vector2>().x * _speed * Time.deltaTime;
        float inputY = movementValue.Get<Vector2>().y * _speed * Time.deltaTime;

        transform.position = _targetPosition;
        transform.Rotate(Vector3.up, inputX, Space.World);
        transform.Rotate(Vector3.right, -inputY, Space.Self);
        transform.Translate(Vector3.back * _distance);
    }
}
