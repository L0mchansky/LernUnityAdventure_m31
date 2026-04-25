using System;
using System.Collections;
using UnityEngine;

namespace LernUnityAdventure_m31
{
    public class LauncherProjectiles : ILaunch
    {
        private CoroutineStartService _launchService;
        private ProjectileConfig _projectileSettings;
        private MonoBehaviour _runner;

        public LauncherProjectiles(CoroutineStartService launchService, ProjectileConfig projectileSettings, MonoBehaviour runner)
        {
            _launchService = launchService;
            _projectileSettings = projectileSettings;
            _runner = runner;
        }

        public void Launch(Vector3 startPosition, Vector3 launchDirection)
        {
            Projectile projectile = GameObject.Instantiate(_projectileSettings.ProjectilePrefab);
            projectile.Initialize(_projectileSettings);

            _launchService.StartCoroutine(Run(projectile, startPosition, launchDirection));
        }

        private IEnumerator Run(Projectile projectile, Vector3 startPosition, Vector3 launchDirection)
        {
            Timer timer = new(projectile.Lifetime, _runner);
            timer.Start();

            projectile.transform.position = startPosition;

            while (timer.IsRunning)
            {
                projectile.transform.position += Time.fixedDeltaTime * launchDirection * projectile.Speed;
                yield return null;
            }

            projectile.Dispose();
        }
    }
}