using UnityEngine;

namespace Inputs
{
    public interface IInput
    {
        Vector2 GetDirection();
        bool IsFireActionPressed();
    }
}