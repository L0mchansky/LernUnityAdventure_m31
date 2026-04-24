using System;
using UnityEngine;

namespace LernUnityAdventure_m31
{
    [CreateAssetMenu(fileName = "NewProjectile", menuName = "Game/Projectile")]
    public class ProjectileSettings: ScriptableObject
    {
        [field: SerializeField]  public Projectile ProjectilePrefab { get; private set; }
        [field: SerializeField]  public float Damage { get; private set; }
        [field: SerializeField]  public float Lifetime { get; private set; }
        [field: SerializeField]  public float Speed { get; private set; }
    }
}
