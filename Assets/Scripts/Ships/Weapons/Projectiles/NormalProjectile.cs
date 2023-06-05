using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    public class NormalProjectile : Projectile
    {
        [SerializeField] private float speed;

        protected override void DoStart()
        {
            Debug.Log("Init normal projectile");
        }

        protected override void DoMove()
        {
            ProjectileMovement();
        }

        private void ProjectileMovement()
        {
            rb2D.velocity = myTransform.up * speed;
        }
        

        protected override void DoDestroy()
        {
            Debug.Log("Se destruye projectil" + gameObject.name);
        }
    }
    
}
