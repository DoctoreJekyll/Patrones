using UnityEngine;

namespace Ships
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float speed;
        private IInput inputInterface;
        private ICheckLimits checkLimitsInterface;
        private Transform myTransform;

        private void Awake()
        {
            myTransform = transform;
        }

        public void Configure(IInput inputTemp, ICheckLimits checkLimits)
        {
            this.inputInterface = inputTemp;
            this.checkLimitsInterface = checkLimits;
        }

        private void Update()
        {
            var direction = GetDirection();
            Move(direction);
        }

        private void Move(Vector2 direction)
        {
            myTransform.Translate(direction * (speed * Time.deltaTime));
            checkLimitsInterface.ClampFinalPos();
        }

        private Vector2 GetDirection()
        {
            return inputInterface.GetDirection();
        }
    }
}
