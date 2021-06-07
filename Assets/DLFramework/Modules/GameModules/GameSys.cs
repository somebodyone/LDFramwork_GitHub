using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DLBASE
{
    public class GameSys : ISys
    {
        private IGame m_Game;
        public GameObject m_GameRoot;
        public Camera m_GameCamera;

        /// <summary>
        /// 初始化系统
        /// </summary>
        public override void _InitSys()
        {            
            m_GameRoot = new GameObject();
            m_GameRoot.name = "GameRoot";
        }

        /// <summary>
        /// 创建新游戏
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public T CreatGame<T>()where T: IGame, new ()
        {
            if (m_Game == null)
            {
                m_Game = new T();
            }
            return m_Game as T;
        }

        /// <summary>
        /// 获取游戏
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetGame<T>()where T : GameSys, new()
        {
            return m_Game as T;
        }

        /// <summary>
        /// 刷新游戏
        /// </summary>
        public virtual void UpdateGame()
        {
            m_Game._UpdateGame();
        }
    }
}