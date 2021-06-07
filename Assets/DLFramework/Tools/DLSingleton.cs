using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLBASE
{
    public class DLSingleton 
    {
        private static DLSingleton ins;
        public static DLSingleton Ins
        {
            get
            {
                if(ins == null)
                {
                    ins = new DLSingleton();
                }
                return ins;
            }
        }
    }
}
