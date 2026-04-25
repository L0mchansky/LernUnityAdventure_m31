using System;

namespace LernUnityAdventure_m31
{
    public class MonoDestroyDisposable : MonoDestroyable, IDisposable
    {
        public void Dispose()
        {
            Destroy();
        }
    }
}