using System;
using UnityEngine;

namespace Patterns.Mediator
{
    public class SteeringWheel : MonoBehaviour
    {
        private IVehicleMediator vehicleMediator;
        
        public void Configure(IVehicleMediator vehicleMediatorT)
        {
            this.vehicleMediator = vehicleMediatorT;
        }

        private void Update()
        {
            if (Input.GetButtonDown("Left"))
            {
                vehicleMediator.LeftPressed();
            }
            else if (Input.GetButtonDown("Right"))
            {
                vehicleMediator.RigthPressed();
            }
        }
    }
}
