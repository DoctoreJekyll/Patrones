using System;
using System.Linq;
using Inputs;
using UnityEngine;

namespace Ships.Weapons
{
    public class WeaponController : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private ProjectilesConfiguration configuration;
        [SerializeField] private Projectile dejaultProjectile;

        [Header("Values")]
        [SerializeField] private float couldownShoot;
        [SerializeField] private Transform shootSpawnPos;
        [SerializeField] private float timeToBeAbleToShoot;
        
        private ProjectileFactory factory;
        private string activeProjectileId;
        private IShip iShip;

        private void Awake()
        {
            factory = new ProjectileFactory(Instantiate(configuration));
        }

        //Base configuracion
        public void Configure(IShip iShipT)
        {
            iShip = iShipT;
            activeProjectileId = dejaultProjectile.Id;
        }

        public void TryShoot()
        {
            timeToBeAbleToShoot -= Time.deltaTime;
            if (timeToBeAbleToShoot > 0)
            {
                return;
            }
            
            Shoot();
        }
        
        private void Shoot()
        {
            //Busqueda del primer identificador usando First(metodo de Linq)
            //Projectile prefab = projectile.First(projectile1 => projectile1.Id.Equals(activeProjectileId));
            
            timeToBeAbleToShoot = couldownShoot;
            factory.Create(SetActiveProjectileId(activeProjectileId), shootSpawnPos, shootSpawnPos.rotation);
        }

        //Si cogemos un powerup o algun cambio de projectile llamamos a esta clase
        public string SetActiveProjectileId(string newId)
        {
            activeProjectileId = newId;
            return activeProjectileId;
        }
    }
}