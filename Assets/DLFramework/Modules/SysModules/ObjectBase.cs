using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLBASE
{
    public class ObjectBase : GameBase
    {
        public void DestoryObj(GameObject go)
        {
            Destroy(go);
        }

        public GameObject InstantiateGO(GameObject go)
        {
            GameObject gameObject = Instantiate(go);
            return gameObject;
        }

        public void StartCortinue(IEnumerator enumerator)
        {
            StartCoroutine(enumerator);
        }
    }
}
