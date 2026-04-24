using System;
using System.Collections;
using UnityEngine;

namespace LernUnityAdventure_m31
{
    public class LauncherProjectiles : ILaunch
    {
        private BulletType _bulltetType;
        private CoroutineStartService _launchService;
        private ProjectileSettings _projectileSettings;

        public LauncherProjectiles(BulletType bulletType, CoroutineStartService launchService, ProjectileSettings projectileSettings)
        {
            _bulltetType = bulletType;
            _launchService = launchService;
            _projectileSettings = projectileSettings;
        }

        public void Launch(Vector3 startPosition, Vector3 launchDirection)
        {
            //Вынести в фабрику
            Projectile projectile = GameObject.Instantiate(_projectileSettings.ProjectilePrefab);
            projectile.Initialize(_projectileSettings);

            _launchService.StartCoroutine(projectile, startPosition, launchDirection);
        }
    }
}