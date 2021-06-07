using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLBASE
{
    public class ISys
    {
        public ISys()
        {
            _InitSys();
        }
        public virtual void _InitSys() { }
        public virtual void _UpdateSys() { }
    }
}

