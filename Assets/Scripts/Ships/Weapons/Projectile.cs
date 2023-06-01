using System;
using System.Collections;
using UnityEngine;

namespace Ships.Weapons
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Rigidbody2D rb2D;

        public string id;

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
