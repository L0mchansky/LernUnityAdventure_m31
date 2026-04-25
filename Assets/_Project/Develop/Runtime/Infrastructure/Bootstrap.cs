using UnityEngine;

namespace LernUnityAdventure_m31
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] Character _character;
        [SerializeField] CharacterEnemy _characterEnemy;

        [SerializeField] BulletConfig _bulletConfig;

        private PlayerDirectionalMovableController _playerDirectionalMovableController;
        private PlayerDirectionalRotatableController _playerDirectionalRotatableController;
        private PlayerShootController _playerLauncherController;

        private CoroutineStartService _coroutineStartService;

        private RandomAIDirectionalMovableController _randomAIDirectionalMovableController;
        private AlongMovableVelocityRotatableController _alongMovableVelocityRotatableController;


        void Awake()
        {
            _coroutineStartService = new (this);

            LauncherProjectileFactory launcherFactory = new (_bulletConfig, _coroutineStartService, this);
            LauncherProjectiles launcherProjectiles = launcherFactory.GetLaunch(LauncherProjectileType.Bullet);

            // ак именно будут двигатьс€ / поворачиватьс€
            _character.Initialize(
                new CharacterControllerDirectionalMover(_character.GetComponent<CharacterController>(), 10),
                new TransformDirectionalRotator(_character.transform, 500),
                launcherProjectiles
                );

            _characterEnemy.Initialize(
                new CharacterControllerDirectionalMover(_characterEnemy.GetComponent<CharacterController>(), 5),
                new TransformDirectionalRotator(_characterEnemy.transform, 500)
                );

            //„то будет двигать / поворачивать

            _playerDirectionalMovableController = new (_character);
            _playerDirectionalMovableController.Enable();

            _playerDirectionalRotatableController = new (_character);
            _playerDirectionalRotatableController.Enable();

            _playerLauncherController = new (_character);
            _playerLauncherController.Enable();


            _randomAIDirectionalMovableController = new (_characterEnemy, 3);
            _randomAIDirectionalMovableController.Enable();

            _alongMovableVelocityRotatableController = new AlongMovableVelocityRotatableController(_characterEnemy, _characterEnemy);
            _alongMovableVelocityRotatableController.Enable();
        }

        void Update()
        {
            _playerDirectionalMovableController.Update(Time.fixedDeltaTime);
            _playerDirectionalRotatableController.Update(Time.fixedDeltaTime);
            _playerLauncherController.Update(Time.fixedDeltaTime);

            _randomAIDirectionalMovableController.Update(Time.fixedDeltaTime);
            _alongMovableVelocityRotatableController.Update(Time.fixedDeltaTime);
        }
    }
}
