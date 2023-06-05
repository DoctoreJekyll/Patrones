using System;
using System.Collections;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D rb2D;
        [SerializeField] private string id;
        public string Id => id;
        
        protected Transform myTransform;

        private void Start()
        {
            myTransform = transform;
            DoStart();
            StartCoroutine(DestroyIn(5f));
        }

        protected abstract void DoStart();

        private void FixedUpdate()
        {
            DoMove();
        }

        protected abstract void DoMove();

        private IEnumerator DestroyIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            DestroyProjectile();
        }

        private void DestroyProjectile()
        {
            DoDestroy();
            Destroy(gameObject);
        }

        protected abstract void DoDestroy();

        private void OnTriggerEnter2D(Collider2D col)
        {
            DestroyProjectile();
            //Damage
        }
    }
}
