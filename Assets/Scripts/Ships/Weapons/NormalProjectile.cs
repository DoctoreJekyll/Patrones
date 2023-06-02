using UnityEngine;
using System.Collections;
using System;

namespace Ships.Weapons
{
    public class NormalProjectile : Projectile
    {
        [SerializeField] private float speed;
        [SerializeField] private Rigidbody2D rb2D;

        private void Start()
        {
            StartCoroutine(DestroyIn(4f));
        }

        private void FixedUpdate()
        {
            ProjectileMovement();
        }

        private void ProjectileMovement()
        {
            rb2D.velocity = transform.up * speed;
        }

        private IEnumerator DestroyIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }
    
}
