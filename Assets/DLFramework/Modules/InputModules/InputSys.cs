using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLBASE
{
    public class InputSys : ISys
    {
        public delegate void OnMouseDownDelegate(Transform transform);
        public delegate void OnMouseUpDelegage(Transform transform);
        public delegate void OnMouseDragDelegate(Transform transform);

        private OnMouseDownDelegate m_OnMouseDownDelegate;
        private OnMouseUpDelegage m_OnMouseUpDelegage;
        private OnMouseDragDelegate m_OnMouseDragDelegate;
        //检测开关
        private bool m_Detection = true;

        public override void _InitSys()
        {
            
        }

        /// <summary>
        /// 点击
        /// </summary>
        /// <param name="transform"></param>
        public  void _OnMouseDown(Transform transform)
        {
            if (!m_Detection) return;
            m_OnMouseDownDelegate?.Invoke(transform);
        }
        /// <summary>
        /// 抬起
        /// </summary>
        /// <param name="transform"></param>
        public  void _OnMouseUp(Transform transform)
        {
            if (!m_Detection) return;
            m_OnMouseUpDelegage?.Invoke(transform);
        }
        /// <summary>
        /// 拖动
        /// </summary>
        /// <param name="transform"></param>
        public  void _OnMouseDrag(Transform transform)
        {
            if (!m_Detection) return;
            m_OnMouseDragDelegate?.Invoke(transform);
        }

        public void OnMouseDown(OnMouseDownDelegate onMouseDownDelegate)
        {
            m_OnMouseDownDelegate += onMouseDownDelegate;
        }

        public void OnMouseUp(OnMouseUpDelegage onMouseUpDelegage)
        {
            m_OnMouseUpDelegage += onMouseUpDelegage;
        }

        public void OnMouseDrag(OnMouseDragDelegate onMouseDragDelegate)
        {
            m_OnMouseDragDelegate += onMouseDragDelegate;
        }

        public void Open()
        {
            Debug.Log("开启检测！！！！");
            m_Detection = true;
        }
        public void Close()
        {
            Debug.Log("关闭检测！！！！");
            m_Detection = false;
        }
    }
}
