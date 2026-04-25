using UnityEngine;

namespace LernUnityAdventure_m31
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] Character _character;
        [SerializeField] ProjectileConfig _projectileSettings;

        private PlayerCharacterController _playerCharacterController;
        private PlayerLauncherController _playerLauncherController;


        void Awake()
        {
            CoroutineStartService coroutineStartService = new (this);

            _character.Initialize(
                new CharacterControllerDirectionalMover(_character.GetComponent<CharacterController>(), 10),
                new DirectionalRotator(_character.transform, 500),
                new LauncherProjectiles(BulletType.Sphere, coroutineStartService, _projectileSettings) //TODO: Завернуть в фабрику
                );

            _playerCharacterController = new PlayerCharacterController(_character);
            _playerCharacterController.Enable();

            _playerLauncherController = new PlayerLauncherController(_character);
            _playerLauncherController.Enable();
        }   
         

        void Update()
        {
            _playerCharacterController.Update(Time.deltaTime);
            _playerLauncherController.Update(Time.deltaTime);
        }
    }
}
