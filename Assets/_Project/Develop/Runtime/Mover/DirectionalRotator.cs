using UnityEngine;
using UnityEngine.UIElements;

public class DirectionalRotator 
{
    private Transform _transform;
    private float _rotationSpeed;
    private Vector3 _currentDirection;

    public DirectionalRotator(Transform transform, float rotationSpeed)
    {
        _rotationSpeed = rotationSpeed;
        _transform = transform;
    }

    public Quaternion CurrentRotation => _transform.rotation;

    public void SetInputDirection(Vector3 direction) => _currentDirection = direction;

    public void Update(float deltaTime)
    {
        if (_currentDirection.magnitude < 0.05f)
            return;

        Quaternion lookRotation = Quaternion.LookRotation(_currentDirection.normalized);

        float step = _rotationSpeed * deltaTime;

        ApplyRotation(Quaternion.RotateTowards(CurrentRotation, lookRotation, step));
    }

    private void ApplyRotation(Quaternion rotation) => _transform.rotation = rotation;
}
