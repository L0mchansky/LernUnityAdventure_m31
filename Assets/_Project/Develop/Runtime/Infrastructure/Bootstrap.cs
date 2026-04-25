using UnityEngine;

namespace LernUnityAdventure_m31
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] Character _character;

        [SerializeField] ProjectileConfig _projectileConfig;

        private PlayerCharacterController _playerCharacterController;
        private PlayerLauncherController _playerLauncherController;

        private CoroutineStartService _coroutineStartService;


        void Awake()
        {
            _coroutineStartService = new (this);

            LauncherFactory launcherFactory = new (_projectileConfig, _coroutineStartService, this);
            ILaunch launcherProjectiles = launcherFactory.GetLaunch(LauncherType.Projectile);

            _character.Initialize(
                new CharacterControllerDirectionalMover(_character.GetComponent<CharacterController>(), 10),
                new DirectionalRotator(_character.transform, 500),
                launcherProjectiles
                );

            _playerCharacterController = new PlayerCharacterController(_character);
            _playerCharacterController.Enable();

            _playerLauncherController = new PlayerLauncherController(_character);
            _playerLauncherController.Enable();
        }

        void Update()
        {
            _playerCharacterController.Update(Time.fixedDeltaTime);
            _playerLauncherController.Update(Time.fixedDeltaTime);
        }
    }
}
