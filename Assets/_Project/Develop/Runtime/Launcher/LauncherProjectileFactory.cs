using UnityEngine;

namespace LernUnityAdventure_m31
{
    public class LauncherProjectileFactory
    {
        private BulletConfig _projectileConfig;
        private CoroutineStartService _launchService;
        private MonoBehaviour _runner;

        public LauncherProjectileFactory(BulletConfig launcherConfig, CoroutineStartService launchService, MonoBehaviour runner)
        {
            _projectileConfig = launcherConfig;
            _launchService = launchService;
            _runner = runner;
        }

        public ILaunch GetLaunch(LauncherProjectileType type)
        {
            switch (type)
            {
                case LauncherProjectileType.Bullet:
                    return GetNewLauncherProjectiles();
                default:
                    return null;
            }
        }

        private LauncherProjectiles GetNewLauncherProjectiles() => new (_launchService, _projectileConfig, _runner);
    }
}
