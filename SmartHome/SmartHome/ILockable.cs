using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome
{
    internal interface ILockable
    {
        public bool Unlock();
        public bool Lock();
    }

}

