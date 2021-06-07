using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLBASE;

namespace DLAM
{
    public class Game : GameBase
    {
        public override void _Init()
        {
            SysManager.InitSys();
            SysManager.LoadSys<GameSys>(SysEnum.GameSys);
            SysManager.LoadSys<UISys>(SysEnum.UISys);
        }

        public override void _OnStart()
        {

        }
    }
}
