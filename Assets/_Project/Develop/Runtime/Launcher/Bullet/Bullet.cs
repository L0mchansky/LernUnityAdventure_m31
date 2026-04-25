using System;
using UnityEngine;

namespace LernUnityAdventure_m31
{
    public class Bullet : MonoDestroyDisposable
    {
        public void Initialize(BulletConfig projectileSettings)
        {
            Damage = projectileSettings.Damage;
            Lifetime = projectileSettings.Lifetime;
            Speed = projectileSettings.Speed;
        }

        public float Damage { get; private set; }
        public float Lifetime { get; private set; }
        public float Speed { get; private set; }
    }
}
