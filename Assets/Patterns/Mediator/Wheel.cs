using UnityEngine;

namespace Patterns.Mediator
{
    public class Wheel : MonoBehaviour
    {
        private IVehicleMediator vehicleMediator;

        public void Configure(IVehicleMediator mediator)
        {
            this.vehicleMediator = mediator;
        }
        
        public void AddFriction()
        {
        }

        public void RemoveFriction()
        {
        }

        public void TurnLeft()
        {
        }

        public void TurnRight()
        {
        }
    }
}
