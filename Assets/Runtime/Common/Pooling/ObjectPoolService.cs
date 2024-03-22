using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace MystiCorp.Runtime.Common.Pooling
{
    public abstract class ObjectPoolService : ScriptableObject
    {
        [SerializeField]
        private GameObject prefab;

        private Transform poolParent;
        private ObjectPool<GameObject> pool;
        protected List<GameObject> activeObjects;

        protected GameObject GetObject()
        {
            if (pool == null || poolParent == null) InitializePool();

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

        private void InitializePool()
        {
            // dispose if active
            if (poolParent != null) Destroy(poolParent.gameObject);
            pool?.Dispose();

            // initialize
            poolParent = new GameObject(GetType().Name).transform;
            activeObjects = new();
            pool = new(
                createFunc: CreateObject,
                actionOnDestroy: DestroyObject);
        }

        protected virtual GameObject CreateObject()
        {
            return Instantiate(prefab, poolParent);
        }

        protected virtual void DestroyObject(GameObject obj)
        {
            Destroy(obj);
        }
    }
}
