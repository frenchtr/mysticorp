using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MystiCorp.Runtime
{
    public class Poolable : MonoBehaviour
    {
        public event Action Spawned;
        public event Action Despawned;

        public void Spawn()
        {
            Spawned?.Invoke();
        }

        public void Despawn()
        {
            Despawned?.Invoke();
            Despawned = null;
        }
    }
}
