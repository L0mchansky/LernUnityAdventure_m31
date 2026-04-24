using UnityEngine;
using UnityEngine.TextCore.Text;

namespace LernUnityAdventure_m31
{
    public class Character : MonoDestroyable
    {
        [SerializeField] Transform _virtualCamera;
        [SerializeField] Transform _launchPoint;

        private CharacterControllerDirectionalMover _mover;
        private DirectionalRotator _rotator;
        private ILaunch _launcher;

        public Vector3 CurrentVelocity => _mover.CurrentVelocity;

        public void Initialize(CharacterControllerDirectionalMover mover, DirectionalRotator rotator, ILaunch launcher)
        {
            _mover = mover;
            _rotator = rotator;
            _launcher = launcher;

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

        public void Launch() => _launcher.Launch(_launchPoint.position, _launchPoint.forward);
    }
}