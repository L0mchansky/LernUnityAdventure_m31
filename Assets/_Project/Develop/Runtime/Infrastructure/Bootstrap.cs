using UnityEngine;

namespace LernUnityAdventure_m31
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] Character _character;

        [SerializeField] ProjectileConfig _projectileConfig;

        private PlayerDirectionalMovableController _playerDirectionalMovableController;
        private PlayerDirectionalRotatableController _playerDirectionalRotatableController;
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
