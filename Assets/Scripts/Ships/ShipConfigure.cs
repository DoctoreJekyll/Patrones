using Inputs;
using UnityEngine;

namespace Ships
{
    public class ShipConfigure : MonoBehaviour
    {
        [SerializeField] private ShipMediator shipMediator;
        [SerializeField] private Joystick joystick;
        [SerializeField] private JoyButton joyButton;
        [SerializeField] private bool isUsingJoystic;
        [SerializeField] private bool useIA;

        private void Awake()
        {
            shipMediator.Configure(GetInput(), CheckLimits());
        }

        private IInput GetInput()
        {
            if (useIA)
            {
                return new AIInputAdapter(shipMediator);
            }
            
            if (isUsingJoystic)
            {
                return new JoystickInputAdapter(joystick, joyButton);
            }
            Destroy(joystick.gameObject);
            Destroy(joyButton.gameObject);

            return new UnityInputAdapter();
        }

        private ICheckLimits CheckLimits()
        {
            if (useIA)
            {
                return new InitialPosCheckLimits(shipMediator.transform, 10f);
            }
            
            return new ViewportCheckLimits(shipMediator.transform);
        }
    }
}