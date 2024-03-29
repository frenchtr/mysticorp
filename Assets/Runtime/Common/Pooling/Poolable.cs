using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MystiCorp.Runtime
{
    public class Poolable : MonoBehaviour
    {
        public event Action ReturnToPool;

        public void Return()
        {
            ReturnToPool?.Invoke();
            ReturnToPool = null;
        }
    }
}
