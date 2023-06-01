using System;
using UnityEngine;

namespace Patterns.Mediator
{
    //Este va a ser mi mediador central
    public class VehicleMediator : MonoBehaviour, IVehicleMediator
    {
        [SerializeField] private Wheel[] wheels;
        [SerializeField] private VehicleLight[] vehicleLights;
        [SerializeField] private SteeringWheel steeringWheel;
        [SerializeField] private Brake brake;

        private void Awake()
        {
            foreach (Wheel wheel in wheels)
            {
                wheel.Configure(this);
            }
            foreach (VehicleLight vLight in vehicleLights)
            {
                vLight.Configure(this);
            }
            brake.Configure(this);
            steeringWheel.Configure(this);
        }

        public void BrakeRelease()
        {
            foreach (var wheel in wheels)
            {
                wheel.AddFriction();
            }

            foreach (var brakeLight in vehicleLights)
            {
                brakeLight.TurnOn();
            }
        }

        public void BrakeUnrelease()
        {
            foreach (var wheel in wheels)
            {
                wheel.RemoveFriction();
            }

            foreach (var brakeLight in vehicleLights)
            {
                brakeLight.TurnOff();
            }
        }

        public void LeftPressed()
        {
            foreach (var wheel in wheels)
            {
                wheel.TurnLeft();
            }
        }

        public void RigthPressed()
        {
            foreach (var wheel in wheels)
            {
                wheel.TurnRight();
            }
        }
    }
}