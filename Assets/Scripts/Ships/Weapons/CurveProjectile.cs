using UnityEngine;
using System.Collections;

namespace Ships.Weapons
{
    public class CurveProjectile : Projectile
    {
        [SerializeField] private float speed;
        [SerializeField] private Rigidbody2D rb2D;
        [SerializeField] private AnimationCurve horizontalPosCurve;

        private Transform myTransform;
        private Vector3 currentPos;
        private float currenTime;


        private void Start()
        {
            myTransform = transform;
            
            StartCoroutine(DestroyIn(4f));
            currentPos = myTransform.position;
            currenTime = 0f;
        }

        private void FixedUpdate()
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

        private IEnumerator DestroyIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }
}