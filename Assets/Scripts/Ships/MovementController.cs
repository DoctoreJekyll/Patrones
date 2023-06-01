﻿using UnityEngine;

namespace Ships
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float speed;
        
        private IShip iShip;
        private Transform myTransform;
        private ICheckLimits checkLimitsInterface;

        private void Awake()
        {
            myTransform = transform;
        }
        
        public void Configure(IShip iShipT, ICheckLimits checkLimits)
        {
            iShip = iShipT;
            checkLimitsInterface = checkLimits;
        }
        
        public void Move(Vector2 direction)
        {
            myTransform.Translate(direction * (speed * Time.deltaTime));
            checkLimitsInterface.ClampFinalPos();
        }
    }
}