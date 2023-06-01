using Inputs;
using Ships.Weapons;
using UnityEngine;

namespace Ships
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float couldownShoot;
        [SerializeField] private Projectile projectile;
        [SerializeField] private Transform shootSpawnPos;
        
        private IInput inputInterface;
        private ICheckLimits checkLimitsInterface;
        private Transform myTransform;
        private float timeToBeAbleToShoot;

        private void Awake()
        {
            myTransform = transform;
            //DependencyInjection();
        }

        public void Configure(IInput inputInterfaceParam, ICheckLimits checkLimitsInterfaceParam)
        {
            this.inputInterface = inputInterfaceParam;
            this.checkLimitsInterface = checkLimitsInterfaceParam;
        }

        //Injeccion de dependencias vieja, estamos injectando desde un configurador pero esto tambien serviria
        private void DependencyInjection()
        {
            inputInterface = new UnityInputAdapter();
            checkLimitsInterface = new ViewportCheckLimits(myTransform);
        }

        private void Update()
        {
            var direction = GetDirection();
            Move(direction);
            TryShoot();
        }

        private void Move(Vector2 direction)
        {
            myTransform.Translate(direction * (speed * Time.deltaTime));
            checkLimitsInterface.ClampFinalPos();
        }

        private void TryShoot()
        {
            timeToBeAbleToShoot -= Time.deltaTime;
            if (timeToBeAbleToShoot > 0)
            {
                return;
            }

            if (inputInterface.IsFireActionPressed())
            {
                Shoot();
            }
            
        }

        private void Shoot()
        {
            timeToBeAbleToShoot = couldownShoot;
            Instantiate(projectile, shootSpawnPos.position, shootSpawnPos.rotation);

        }

        private Vector2 GetDirection()
        {
            return inputInterface.GetDirection();
        }
    }
}
