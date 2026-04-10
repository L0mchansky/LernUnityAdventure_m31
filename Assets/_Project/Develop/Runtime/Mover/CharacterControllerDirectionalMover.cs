using UnityEngine;

public class CharacterControllerDirectionalMover
{
    private CharacterController _characterController;
    private float _movementSpeed;
    private Vector3 _currentDirection;

    public CharacterControllerDirectionalMover(CharacterController characterController, float movementSpeed)
    {
        _characterController = characterController;
        _movementSpeed = movementSpeed;
    }

    public Vector3 CurrentVelocity => _currentDirection.normalized * _movementSpeed;

    public void SetInputDirection(Vector3 direction) => _currentDirection = direction;

    public void Update(float deltaTime) =>_characterController.Move(CurrentVelocity * deltaTime);
}
