using Inputs;
using Ships.Weapons;
using UnityEngine;

namespace Ships
{
    public class ShipMediator : MonoBehaviour, IShip
    {
        [SerializeField] private MovementController movementController;
        [SerializeField] private WeaponController weaponController;
        [SerializeField] private ShipId shipId;
        public ShipId ShipId => shipId;

        private IInput inputInterface;

        private void Awake()
        {
            //DependencyInjection();
        }

        public void Configure(IInput inputInterfaceParam, ICheckLimits checkLimitsInterfaceParam)
        {
            this.inputInterface = inputInterfaceParam;
            movementController.Configure(this, checkLimitsInterfaceParam);
            weaponController.Configure(this);
        }

        //Injeccion de dependencias vieja, estamos injectando desde un configurador pero esto tambien serviria
        private void DependencyInjection()
        {
            //inputInterface = new UnityInputAdapter();
            //checkLimitsInterface = new ViewportCheckLimits(myTransform);
        }

        private void Update()
        {
            var direction = GetDirection();
            movementController.Move(direction);
            TryShoot();
        }

        private void TryShoot()
        {
            if (inputInterface.IsFireActionPressed())
            {
                weaponController.TryShoot();
            }
        }

        private Vector2 GetDirection()
        {
            return inputInterface.GetDirection();
        }
    }
}
