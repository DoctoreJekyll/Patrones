using Ships;
using UnityEngine;

namespace Inputs
{
    public class AIInputAdapter : IInput
    {

        private readonly ShipMediator shipMediator;
        private float currentDirX;

        public AIInputAdapter(ShipMediator shipMediator)
        {
            this.shipMediator = shipMediator;
            currentDirX = 1;
        }

        public Vector2 GetDirection()
        {
            Vector3 viewportPoint = Camera.main.WorldToViewportPoint(shipMediator.transform.position);
            if (viewportPoint.x < 0.05f)
            {
                currentDirX = shipMediator.transform.right.x;
            }
            else if (viewportPoint.x > 0.95f)
            {
                currentDirX = -shipMediator.transform.right.x;
            }
            return new Vector2(currentDirX, 1);
        }

        public bool IsFireActionPressed()
        {
            return Random.Range(0, 100) < 20;
        }
    }
}