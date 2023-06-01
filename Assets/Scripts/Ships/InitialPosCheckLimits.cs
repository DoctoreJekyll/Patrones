using UnityEngine;

namespace Ships
{
    class InitialPosCheckLimits : ICheckLimits
    {

        private readonly Transform transform;
        private readonly Vector3 initialPos;
        private readonly float maxDistance;

        public InitialPosCheckLimits(Transform transform, float maxDistance)
        {
            this.transform = transform;
            this.maxDistance = maxDistance;
            initialPos = transform.position;
        }

        public void ClampFinalPos()
        {
            Vector3 currentPos = transform.position;
            Vector3 finalPos = currentPos;
            float distance = Mathf.Abs(currentPos.x - initialPos.x);
            if (distance > maxDistance)
            {
                if (currentPos.x > initialPos.x)
                {
                    finalPos.x = initialPos.x + maxDistance;
                }
                else
                {
                    finalPos.x = initialPos.x - maxDistance;
                }

                transform.position = finalPos;
            }
        }
    }
}