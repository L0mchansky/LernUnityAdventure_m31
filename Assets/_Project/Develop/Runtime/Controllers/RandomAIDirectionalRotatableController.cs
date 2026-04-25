using UnityEngine;

namespace LernUnityAdventure_m31
{
    public class RandomAIDirectionalRotatableController : Controller
    {
        private IDirectionalRotatable _rotatable;

        private float _time;
        private float _timeToChangeDirection;

        Vector3 _inputDirection;

        public RandomAIDirectionalRotatableController(IDirectionalRotatable rotatable, float timeToChangeDirection)
        {
            _rotatable = rotatable;
            _timeToChangeDirection = timeToChangeDirection;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            _time += deltaTime;

            if (_time >= _timeToChangeDirection)
            {
                _inputDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
                _time = 0;
            }

            _rotatable.SetRotationDirection(_inputDirection);
        }
    }
}