using UnityEngine;

namespace LernUnityAdventure_m31
{
    public class CharacterEnemy : MonoDestroyDisposable, IDirectionalMovable, IDirectionalRotatable
    {
        private DirectionalMover _mover;
        private DirectionalRotator _rotator;

        public Vector3 CurrentVelocity => _mover.CurrentVelocity;

        //TODO: Зачем?
        public Quaternion CurrentRotation => _rotator.CurrentRotation;

        public void Initialize(DirectionalMover mover, DirectionalRotator rotator)
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