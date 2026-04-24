using LernUnityAdventure_m31;
using System.Collections;
using UnityEngine;

namespace LernUnityAdventure_m31
{
    public class CoroutineStartService
    {
        private MonoBehaviour _runner;
        public CoroutineStartService(MonoBehaviour runner) {
            _runner = runner;
        }

        public void StartCoroutine(Projectile projectile, Vector3 startPosition, Vector3 launchDirection)
        {
            _runner.StartCoroutine(
                Run(projectile, startPosition, launchDirection)
                );
        }

        private IEnumerator Run(Projectile projectile, Vector3 startPosition, Vector3 launchDirection)
        {
            Timer timer = new(projectile.Lifetime, _runner);
            timer.Start();

            projectile.transform.position = startPosition;

            while (timer.IsRunning)
            {
                projectile.transform.position += Time.deltaTime * launchDirection * projectile.Speed;
                yield return null;
            }

            projectile.Dispose();
        }
    }
}