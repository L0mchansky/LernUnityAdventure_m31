using UnityEngine;

namespace LernUnityAdventure_m31
{
    public class TransformDirectionalMover : DirectionalMover
    {
        private Transform _transform;

        public TransformDirectionalMover(Transform transform, float movementSpeed) : base(movementSpeed)
        {
            _transform = transform;
        }

        public override void Update(float deltaTime)
        {
            _transform.position += deltaTime * CurrentVelocity;
        }
    }
}