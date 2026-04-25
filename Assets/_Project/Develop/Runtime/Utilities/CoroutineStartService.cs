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

        public void StartCoroutine(IEnumerator enumerator)
        {
            _runner.StartCoroutine(enumerator);
        }
    }
}