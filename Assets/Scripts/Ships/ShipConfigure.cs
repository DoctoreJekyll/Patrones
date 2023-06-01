using Inputs;
using UnityEngine;

namespace Ships
{
    public class ShipConfigure : MonoBehaviour
    {
        [SerializeField] private Ship ship;
        [SerializeField] private Joystick joystick;
        [SerializeField] private JoyButton joyButton;
        [SerializeField] private bool isUsingJoystic;
        [SerializeField] private bool useIA;

        private void Awake()
        {
            ship.Configure(GetInput(), CheckLimits());
        }

        private IInput GetInput()
        {
            if (useIA)
            {
                return new AIInputAdapter(ship);
            }
            
            if (isUsingJoystic)
            {
                return new JoystickInputAdapter(joystick, joyButton);
            }
            Destroy(joystick);
            Destroy(joyButton);

            return new UnityInputAdapter();
        }

        private ICheckLimits CheckLimits()
        {
            if (useIA)
            {
                return new InitialPosCheckLimits(ship.transform, 10f);
            }
            
            return new ViewportCheckLimits(ship.transform);
        }
    }
}