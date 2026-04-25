using System;
using UnityEngine;

namespace LernUnityAdventure_m31
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "Game/Projectile")]
    public class BulletConfig: ScriptableObject
    {
        [field: SerializeField]  public Bullet ProjectilePrefab { get; private set; }
        [field: SerializeField]  public float Damage { get; private set; }
        [field: SerializeField]  public float Lifetime { get; private set; }
        [field: SerializeField]  public float Speed { get; private set; }
    }
}
