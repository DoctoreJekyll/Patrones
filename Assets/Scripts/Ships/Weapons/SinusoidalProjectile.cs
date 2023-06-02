﻿using System.Collections;
using UnityEngine;

namespace Ships.Weapons
{
    public class SinusoidalProjectile : Projectile
    {
        [SerializeField] private float speed;
        [SerializeField] private Rigidbody2D rb2D;
        [SerializeField] private float frequency;
        [SerializeField] private float amplitude;

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
            Vector3 horizontalPosition = myTransform.right * (amplitude * Mathf.Sin(currenTime * frequency));
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