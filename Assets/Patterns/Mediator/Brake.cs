using System;
using UnityEngine;

namespace Patterns.Mediator
{
    public class Brake : MonoBehaviour
    {
        private IVehicleMediator vehicleInterface;

        public void Configure(IVehicleMediator vehicle)
        {
            vehicleInterface = vehicle;
        }

        private void Update()
        {
            if (UnityEngine.Input.GetButtonDown("Break"))
            {
                vehicleInterface.BrakeRelease();
            }
            else if (UnityEngine.Input.GetButtonUp("Break"))
            {
                vehicleInterface.BrakeUnrelease();
            }
        }
    }
}
