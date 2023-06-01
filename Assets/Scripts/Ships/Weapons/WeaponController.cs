using System.Linq;
using Inputs;
using UnityEngine;

namespace Ships.Weapons
{
    public class WeaponController : MonoBehaviour
    {
        
        [SerializeField] private float couldownShoot;
        [SerializeField] private Projectile[] projectile;
        [SerializeField] private Transform shootSpawnPos;

        private string activeProjectileId;
        private float timeToBeAbleToShoot;
        private IShip iShip;

        public void Configure(IShip iShipT)
        {
            iShip = iShipT;
            activeProjectileId = "Projectile2";
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
            Projectile prefab = projectile.First(projectile1 => projectile1.id.Equals(activeProjectileId));
            
            timeToBeAbleToShoot = couldownShoot;
            Instantiate(prefab, shootSpawnPos.position, shootSpawnPos.rotation);
        }
    }
}