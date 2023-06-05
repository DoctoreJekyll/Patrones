using Ships.Weapons.Projectiles;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Ships.Weapons
{
    public class ProjectileFactory 
    {

        private readonly ProjectilesConfiguration configuration;

        public ProjectileFactory(ProjectilesConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Projectile Create(string id, Transform initTransform, Quaternion rotation)
        {
            Projectile projectile = configuration.GetPowerUpByID(id);
            return Object.Instantiate(projectile, initTransform.position ,rotation);
        }



    }
}
