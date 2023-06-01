using UnityEngine;

namespace Inputs
{
    public class UnityInputAdapter : IInput
    {
        public Vector2 GetDirection()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            return new Vector2(horizontal, vertical);
        }

        public bool IsFireActionPressed()
        {
            return Input.GetButton("Fire1");
        }
    }
}