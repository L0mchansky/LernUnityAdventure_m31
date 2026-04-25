using UnityEngine;

namespace LernUnityAdventure_m31
{
    public interface IDirectionalRotatable
    {
        Quaternion CurrentRotation { get; }

        void SetRotationDirection(Vector3 inputDirection);
    }
}