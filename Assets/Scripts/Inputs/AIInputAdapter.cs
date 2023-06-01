using Ships;
using UnityEngine;

namespace Inputs
{
    public class AIInputAdapter : IInput
    {

        private Ship ship;
        private int currentDirX;
        private IInput inputImplementation;

        public AIInputAdapter(Ship ship)
        {
            this.ship = ship;
            currentDirX = 1;
        }

        public Vector2 GetDirection()
        {
            Vector3 viewportPoint = Camera.main.WorldToViewportPoint(ship.transform.position);
            if (viewportPoint.x < 0.05f)
            {
                currentDirX = 1;
            }
            else if (viewportPoint.x > 0.95f)
            {
                currentDirX = -1;
            }
            return new Vector2(currentDirX, 0);
        }

        public bool IsFireActionPressed()
        {
            return Random.Range(0, 100) < 20;
        }
    }
}