using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI界面管理类
/// </summary>
namespace DLBASE
{
    public class UISys : ISys
    {
        private  Dictionary<string, IView> m_IViews = new Dictionary<string, IView>();
        /// <summary>
        /// 父物体
        /// </summary>
        public GameObject m_UIRoot;

        /// <summary>
        /// UI相机
        /// </summary>
        public Camera m_UICamera;

        public override void _InitSys()
        {
            m_UIRoot = new GameObject();
            m_UIRoot.name = "UIRoot";
            Canvas uiroot= m_UIRoot.AddComponent<Canvas>();
            CanvasScaler canvasScaler= m_UIRoot.AddComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.referenceResolution = new Vector2(Screen.width, Screen.height);
            m_UIRoot.AddComponent<GraphicRaycaster>();
            uiroot.renderMode = RenderMode.ScreenSpaceCamera;
            GameObject go = new GameObject();
            go.name = "UICamera";
            m_UICamera = go.AddComponent<Camera>();
            m_UICamera.clearFlags = CameraClearFlags.Depth;
            m_UICamera.cullingMask = 7<<5;
            uiroot.worldCamera = m_UICamera;
        }

        /// <summary>
        /// 分发事件
        /// </summary>
        public  void OpenView<T>(string name, IData data = null) where T : IView
        {
            IView view;
            foreach (string item in m_IViews.Keys)
            {
                if (item == name)
                {
                    m_IViews.TryGetValue(item, out view);
                    view.Show();
                    view.RefreshData(data);
                    return;
                }
            }
            GameObject go =  Object.Instantiate(Resources.Load("UI/" + name) as GameObject);
            go.transform.SetParent(m_UIRoot.transform, false);
            view = go.GetComponent<IView>();
            view.Init();
            view.name = name;
            view.RefreshData(data);
            m_IViews.Add(name, view);
        }

        /// <summary>
        /// 关闭界面
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        public  void CloseView<T>(string name) where T : IView
        {
            IView view;
            foreach (string item in m_IViews.Keys)
            {
                if (item == name)
                {
                    m_IViews.TryGetValue(item, out view);
                    view.Close();
                    return;
                }
            }
        }

        /// <summary>
        /// 获取指定界面
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public  T GetView<T>(string name) where T : IView
        {
            IView view;
            foreach (string item in m_IViews.Keys)
            {
                if (item == name)
                {
                    m_IViews.TryGetValue(item, out view);
                    return (T)view;
                }
            }
            return (T)new IView();
        }
    }
}