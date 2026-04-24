using UnityEngine;

namespace LernUnityAdventure_m31
{
    public class Character : MonoDestroyable
    {
        [SerializeField] Transform _virtualCamera;

        private CharacterControllerDirectionalMover _mover;
        private DirectionalRotator _rotator;

        public Vector3 CurrentVelocity => _mover.CurrentVelocity;

        public void Initialize(CharacterControllerDirectionalMover mover, DirectionalRotator rotator)
        {
            _mover = mover;
            _rotator = rotator;

            foreach (IInitializable initializable in GetComponentsInChildren<IInitializable>())
                initializable.Initialize();
        }

        private void Update()
        {
            _mover.Update(Time.deltaTime);
            _rotator.Update(Time.deltaTime);
        }

        public void SetMoveDirection(Vector3 inputDirection) => _mover.SetInputDirection(inputDirection);

        public void SetRotationDirection(Vector3 inputDirection) => _rotator.SetInputDirection(inputDirection);
    }
}