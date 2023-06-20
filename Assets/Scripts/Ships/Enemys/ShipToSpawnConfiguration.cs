using Ships.Weapons.Projectiles;
using UnityEngine;

namespace Ships.Enemys
{
    [CreateAssetMenu(menuName = "Create ShipToSpawnConfiguration", fileName = "ShipToSpawnConfiguration", order = 0)]
    public class ShipToSpawnConfiguration : ScriptableObject
    {
        [SerializeField] private ShipId shipId;
        [SerializeField] private Projectile defaultProjectileId;
        [SerializeField] private Vector2 speed;
        [SerializeField] private float fireRate;


        public ShipId ShipId => shipId;
        public Projectile DefaultProjectileId => defaultProjectileId;
        public Vector2 Speed => speed;
        public float FireRate => fireRate;
    }
}
