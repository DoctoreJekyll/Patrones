using UnityEngine;

namespace Patterns.Mediator
{
    public class VehicleLight : MonoBehaviour
    {
        [SerializeField] private Light carLight;
        private IVehicleMediator vehicleMediator;

        public void Configure(IVehicleMediator mediator)
        {
            this.vehicleMediator = mediator;
        }
        
        public void TurnOn()
        {
            carLight.enabled = true;
        }

        public void TurnOff()
        {
            carLight.enabled = false;
        }
    }
}
