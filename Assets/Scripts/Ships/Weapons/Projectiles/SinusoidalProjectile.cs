using System.Collections;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    public class SinusoidalProjectile : Projectile
    {
        [SerializeField] private float speed;
        [SerializeField] private float frequency;
        [SerializeField] private float amplitude;
        
        private Vector3 currentPos;
        private float currenTime;

        protected override void DoStart()
        {
            currentPos = MyTransform.position;
            currenTime = 0f;
        }

        protected override void DoMove()
        {
            ProjectileMovementSinusoidal();
        }

        private void ProjectileMovementSinusoidal()
        {
            currentPos += MyTransform.up * (speed * Time.deltaTime);
            Vector3 horizontalPosition = MyTransform.right * (amplitude * Mathf.Sin(currenTime * frequency));
            rb2D.MovePosition(currentPos + horizontalPosition);

            currenTime += Time.deltaTime;
        }

        protected override void DoDestroy()
        {
            Debug.Log("Se destruye projectil" + gameObject.name);
        }
    }
}