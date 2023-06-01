using UnityEngine;

namespace Ships
{
    public class JoystickInputAdapter : IInput
    {

        private readonly Joystick joystick;

        public JoystickInputAdapter(Joystick joystick)
        {
            this.joystick = joystick;
        }

        public Vector2 GetDirection()
        {
            return new Vector2(joystick.Horizontal, joystick.Vertical);
        }
    }
}