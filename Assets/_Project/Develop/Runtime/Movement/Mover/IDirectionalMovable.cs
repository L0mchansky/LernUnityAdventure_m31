using UnityEngine;

namespace LernUnityAdventure_m31
{
    public interface IDirectionalMovable: IMovable
    {
        void SetMoveDirection(Vector3 inputDirection);
    }
}