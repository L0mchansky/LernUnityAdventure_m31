using System.Collections;
using UnityEngine;

namespace LernUnityAdventure_m31
{
    public class Timer
    {
        private float _remainingTime;

        private Coroutine _runCoroutine;
        private MonoBehaviour _runner;

        public Timer(float fullTime, MonoBehaviour runner)
        {
            _remainingTime = fullTime;
            _runner = runner;
        }

        public bool IsRunning => _runCoroutine != null;

        public void Start()
        {
            if (IsRunning == false)
                _runCoroutine = _runner.StartCoroutine(Run());
        }

        public IEnumerator Run()
        {
            while (true)
            {
                Tick(Time.deltaTime);
                yield return null;
            }
        }

        private void Tick(float deltaTime)
        {
            if (_runCoroutine == null) return;

            _remainingTime = _remainingTime - deltaTime;

            if (_remainingTime <= 0)
            {
                _remainingTime = 0;
                Stop();
            }
        }

        private void Stop()
        {
            if (IsRunning)
            {
                _runner.StopCoroutine(_runCoroutine);
                _runCoroutine = null;
            }
        }
    }
}