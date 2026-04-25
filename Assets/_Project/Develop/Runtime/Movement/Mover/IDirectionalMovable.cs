using UnityEngine;

namespace LernUnityAdventure_m31
{
    public interface IDirectionalMovable
    {
        Vector3 CurrentVelocity { get; }
        void SetMoveDirection(Vector3 inputDirection);
    }
}