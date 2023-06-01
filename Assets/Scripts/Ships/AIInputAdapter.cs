using UnityEngine;

namespace Ships
{
    public class AIInputAdapter : IInput
    {

        private Ship ship;
        private readonly int currentDirX;

        public AIInputAdapter(Ship ship)
        {
            this.ship = ship;
            currentDirX = 1;
        }

        public Vector2 GetDirection()
        {
            return new Vector2(currentDirX, 0);
        }
    }
}