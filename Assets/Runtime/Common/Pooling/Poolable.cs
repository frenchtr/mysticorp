using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MystiCorp.Runtime
{
    public class Poolable : MonoBehaviour
    {
        public event Action Retrieved;
        public event Action Returned;

        public void Retrieve()
        {
            Retrieved?.Invoke();
        }

        public void Return()
        {
            Returned?.Invoke();
        }
    }
}
