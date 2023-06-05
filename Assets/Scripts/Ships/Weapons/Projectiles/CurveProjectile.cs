using System.Collections;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    public class CurveProjectile : Projectile
    {
        [SerializeField] private float speed;
        [SerializeField] private AnimationCurve horizontalPosCurve;
        
        private Vector3 currentPos;
        private float currenTime;

        protected override void DoStart()
        {
            currentPos = myTransform.position;
            currenTime = 0f;
        }

        protected override void DoMove()
        {
            ProjectileMovementSinusoidal();
        }

        private void ProjectileMovementSinusoidal()
        {
            currentPos += myTransform.up * (speed * Time.deltaTime);
            Vector3 horizontalPosition = myTransform.right * horizontalPosCurve.Evaluate(currenTime);
            rb2D.MovePosition(currentPos + horizontalPosition);

            currenTime += Time.deltaTime;
        }

        protected override void DoDestroy()
        {
            Debug.Log("Se destruye projectil" + gameObject.name);
        }
    }
}