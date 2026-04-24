using System;
using UnityEngine;

namespace LernUnityAdventure_m31 
{
    public class MonoDestroyable : MonoBehaviour
    {
        public event Action<MonoDestroyable> Destroyed;

        public bool IsDestroyed { get; private set; }

        public void Destroy()
        {
            Destroy(gameObject);

            IsDestroyed = true;
            Destroyed?.Invoke(this);
        }
    }
}
