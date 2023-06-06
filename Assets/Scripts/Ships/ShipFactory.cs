using UnityEngine;
using Object = UnityEngine.Object;

namespace Ships
{
    public class ShipFactory 
    {

        private readonly ShipConfiguration configuration;

        public ShipFactory(ShipConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public ShipMediator Create(string id, Transform initTransform, Quaternion rotation)
        {
            ShipMediator ship = configuration.GetShipUpByID(id);
            return Object.Instantiate(ship, initTransform.position ,rotation);
        }
    }
}