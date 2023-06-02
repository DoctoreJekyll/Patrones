using UnityEngine;
using System;

namespace Ships.Weapons
{
    public class ProjectileFactory : MonoBehaviour
    {

        [SerializeField] private Projectile normalProjectile;

        public Projectile Create(string id, Transform initTransform, Quaternion rotation)
        {
            switch (id)
            {
                case "Normal":
                    return Instantiate(normalProjectile, initTransform.position, rotation);
                default:
                    throw new ArgumentOutOfRangeException($"Power up with {id} does not exist");
            }
        }



    }
}
