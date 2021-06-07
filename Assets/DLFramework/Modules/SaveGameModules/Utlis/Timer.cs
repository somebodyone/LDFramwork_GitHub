using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLBASE
{
    public class Timer : MonoBehaviour
    {
        public int time;
        private static Timer ins;
        public static Timer Ins
        {
            get
            {
                if (ins == null)
                {
                    GameObject NetworkManager = new GameObject("LDTimer");
                    ins = NetworkManager.AddComponent<Timer>();
                }
                return ins;
            }
        }

        public void ResetTimer()
        {
            time = 0;
        }

        public void StartTimer()
        {
            StartCoroutine(_StartTimer());
        }

        public IEnumerator _StartTimer()
        {
            time = 0;
            while (true)
            {
                yield return new WaitForSeconds(1);
                time++;
            }
        }
    }
}
