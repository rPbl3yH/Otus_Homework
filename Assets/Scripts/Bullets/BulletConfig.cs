using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(
        fileName = "BulletConfig",
        menuName = "Bullets/New BulletConfig"
    )]
    public sealed class BulletConfig : ScriptableObject
    {
        public PhysicsLayer PhysicsLayer;
        public Color Color;
        public int Damage;
        public float Speed;
    }
}