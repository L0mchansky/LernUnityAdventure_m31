using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LernUnityAdventure_m31
{
    public class LauncherFactory
    {
        private ProjectileConfig _projectileConfig;
        private CoroutineStartService _launchService;
        private MonoBehaviour _runner;

        public LauncherFactory(ProjectileConfig launcherConfig, CoroutineStartService launchService, MonoBehaviour runner)
        {
            _projectileConfig = launcherConfig;
            _launchService = launchService;
            _runner = runner;
        }

        public ILaunch GetLaunch(LauncherType type)
        {
            switch (type)
            {
                case LauncherType.Projectile:
                    return GetNewLauncherProjectiles();
                default:
                    return null;
            }
        }

        private LauncherProjectiles GetNewLauncherProjectiles() => new (_launchService, _projectileConfig, _runner);
    }
}
