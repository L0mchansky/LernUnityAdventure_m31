using UnityEngine;

namespace LernUnityAdventure_m31
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] Character _character;

        [SerializeField] BulletConfig _bulletConfig;

        private PlayerDirectionalMovableController _playerDirectionalMovableController;
        private PlayerDirectionalRotatableController _playerDirectionalRotatableController;
        private PlayerShootController _playerLauncherController;

        private CoroutineStartService _coroutineStartService;


        void Awake()
        {
            _coroutineStartService = new (this);

            LauncherProjectileFactory launcherFactory = new (_bulletConfig, _coroutineStartService, this);
            LauncherProjectiles launcherProjectiles = launcherFactory.GetLaunch(LauncherProjectileType.Bullet);

            _character.Initialize(
                new CharacterControllerDirectionalMover(_character.GetComponent<CharacterController>(), 10),
                new DirectionalRotator(_character.transform, 500),
                launcherProjectiles
                );

            _playerDirectionalMovableController = new (_character);
            _playerDirectionalMovableController.Enable();

            _playerDirectionalRotatableController = new (_character);
            _playerDirectionalRotatableController.Enable();

            _playerLauncherController = new (_character);
            _playerLauncherController.Enable();
        }

        void Update()
        {
            _playerDirectionalMovableController.Update(Time.fixedDeltaTime);
            _playerDirectionalRotatableController.Update(Time.fixedDeltaTime);
            _playerLauncherController.Update(Time.fixedDeltaTime);
        }
    }
}
