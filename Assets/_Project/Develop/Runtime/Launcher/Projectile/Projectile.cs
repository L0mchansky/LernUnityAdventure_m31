using System;
using UnityEngine;

namespace LernUnityAdventure_m31
{
    public class Projectile : MonoDestroyDisposable
    {
        public float Damage { get; private set; }
        public float Lifetime { get; private set; }
        public float Speed { get; private set; }

        public void Initialize(ProjectileConfig projectileSettings)
        {
            Damage = projectileSettings.Damage;
            Lifetime = projectileSettings.Lifetime;
            Speed = projectileSettings.Speed;
        }
    }
}
