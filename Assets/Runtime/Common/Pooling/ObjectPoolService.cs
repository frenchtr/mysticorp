using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MystiCorp.Runtime.GameManager;
using UnityEngine.Pool;

namespace MystiCorp.Runtime
{
    public abstract class ObjectPoolService : GameServiceManager.Service
    {
        [SerializeField]
        private GameObject prefab;

        private Transform poolParent;
        private ObjectPool<GameObject> pool;
        protected List<GameObject> activeObjects;

        protected GameObject GetObject()
        {
            var obj = pool.Get();

            obj.SetActive(true);
            activeObjects.Add(obj);

            return obj;
        }

        public virtual void Despawn(GameObject obj)
        {
            obj.SetActive(false);
            activeObjects.Remove(obj);

            pool.Release(obj);
        }

        protected override void RuntimeInitializeOnLoad()
        {
            InitializePool();
        }

        private void InitializePool()
        {
            poolParent = new GameObject(GetType().Name).transform;
            activeObjects = new();
            pool = new(CreateObject);
        }

        protected virtual GameObject CreateObject()
        {
            return Instantiate(prefab, poolParent);
        }
    }
}
