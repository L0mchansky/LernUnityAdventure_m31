using System.Collections;
using UnityEngine;

namespace LernUnityAdventure_m31
{
    public class LauncherProjectiles
    {
        private CoroutineStartService _launchService;
        private BulletConfig _projectileSettings;
        private MonoBehaviour _runner;

        public LauncherProjectiles(CoroutineStartService launchService, BulletConfig projectileSettings, MonoBehaviour runner)
        {
            _launchService = launchService;
            _projectileSettings = projectileSettings;
            _runner = runner;
        }

        public void Launch(Vector3 startPosition, Vector3 launchDirection)
        {
            Bullet projectile = GameObject.Instantiate(_projectileSettings.ProjectilePrefab);
            projectile.Initialize(_projectileSettings);
            projectile.transform.position = startPosition;

            TransformDirectionalMover mover = new(projectile.transform, _projectileSettings.Speed);
            mover.SetInputDirection(launchDirection);

            _launchService.StartCoroutine(Run(projectile, startPosition, launchDirection, mover));
        }

        private IEnumerator Run(Bullet projectile, Vector3 startPosition, Vector3 launchDirection, DirectionalMover mover)
        {
            Timer timer = new(projectile.Lifetime, _runner);
            timer.Start();

            while (timer.IsRunning)
            {
                mover.Update(Time.fixedDeltaTime);
                yield return null;
            }

            projectile.Dispose();
        }
    }
}