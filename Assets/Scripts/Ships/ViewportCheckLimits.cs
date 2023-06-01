using UnityEngine;

namespace Ships
{
    class ViewportCheckLimits : ICheckLimits
    {
        private readonly Transform transform;

        public ViewportCheckLimits(Transform transform)
        {
            this.transform = transform;
        }

        public void ClampFinalPos()
        {
            var viewportPoint = Camera.main.WorldToViewportPoint(transform.position);
            viewportPoint.x = Mathf.Clamp(viewportPoint.x, 0.03f, 0.97f);
            viewportPoint.y = Mathf.Clamp(viewportPoint.y, 0.03f, 0.97f);
            transform.position = Camera.main.ViewportToWorldPoint(viewportPoint);
        }
    }
}