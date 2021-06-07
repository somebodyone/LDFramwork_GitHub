
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DLBASE
{

    public class GameUtlis : MonoBehaviour
    {
        public enum WaitType
        {
            Once,
            Reseapt
        }

        public static int RandomAmount(int endAmount)
        {
            int next = UnityEngine.Random.Range(0, endAmount);
            return next;
        }

        public static float RandomAmount(float endAmount)
        {
            float next = UnityEngine.Random.Range(0, endAmount);
            return next;
        }

        public static IEnumerator Wait(float time, Action callback)
        {
            yield return new WaitForSeconds(time);
            callback?.Invoke();
        }

        public static float RangeLimit(float current,float max,float min)
        {
            if (current > max)
            {
                current = max;
            }
            if (current < min)
            {
                current = min;
            }
            return current;
        }

        public static bool ClickUI()
        {
            if (Application.platform == RuntimePlatform.Android ||
                        Application.platform == RuntimePlatform.IPhonePlayer)
            {
                int fingerId = Input.GetTouch(0).fingerId;
                if (EventSystem.current.IsPointerOverGameObject(fingerId))
                {
                    return true;
                }
            }
            //其它平台
            else
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    return true;
                }
            }
            return false;
        }

        public static bool SearchFormElements<T>(Dictionary<int,T> dics,int key)
        {
            foreach(int keys in dics.Keys)
            {
                if (key == keys)
                {
                    return true;
                }
            }
            return false;
        }

        public static string GetGUID()
        {
            Guid guid = new Guid();
            guid = Guid.NewGuid();
            string str = guid.ToString();
            return str;
        }

        public static Vector3 UIToWorld(Camera uicamera,Vector3 pos)
        {
           Vector3 uiPostion = uicamera.WorldToScreenPoint(pos);
            uiPostion.z = 1f;
            uiPostion = Camera.main.ScreenToWorldPoint(uiPostion);
            uiPostion.z = 0;
            return uiPostion;
        }

        public static int GetID(int id)
        {
            if (id <= 10)
            {
                return id;
            }
            id -= 11;
            int index = id / 10;
            id -= index * 10;
            return id+1;
        }
    }

}