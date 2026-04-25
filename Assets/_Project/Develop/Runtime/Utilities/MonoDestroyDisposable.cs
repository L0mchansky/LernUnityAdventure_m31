using LernUnityAdventure_m31;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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