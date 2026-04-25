using UnityEngine;

namespace LernUnityAdventure_m31
{
    public class PlayerShootController : Controller
    {
        private Character _character;

        public PlayerShootController(Character character)
        {
            _character = character;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Space) == false)
            {
                return;
            }

            _character.Launch();
        }
    }
}