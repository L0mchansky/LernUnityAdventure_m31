using System;

namespace LernUnityAdventure_m31
{
    public interface IReadOnlyVariable<T>
    {
        public event Action<T, T> Changed;

        public T Value { get; }
    }
}