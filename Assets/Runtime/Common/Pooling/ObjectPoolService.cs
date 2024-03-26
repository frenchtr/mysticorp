using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace MystiCorp.Runtime.Common.Pooling
{
    public abstract class ObjectPoolService : ScriptableObject
    {
        [SerializeField]
        protected GameObject prefab;

        [System.NonSerialized]
        private Transform poolParent;
        private ObjectPool<GameObject> pool;
        [System.NonSerialized]
        private List<GameObject> activeObjects;

        protected virtual GameObject InstantiatePoolParent() => new(name);

        protected List<GameObject> ActiveObjects
        {
            get
            {
                if (activeObjects == null) InitializePool();
                return activeObjects;
            }
        }

        protected GameObject GetObject()
        {
            if (pool == null || poolParent == null) InitializePool();

            var obj = pool.Get();

            ActiveObjects.Add(obj);

            return obj;
        }

        public virtual void Despawn(GameObject obj)
        {
            obj.SetActive(false);
            ActiveObjects.Remove(obj);

            pool.Release(obj);
        }

        private void InitializePool()
        {
            // dispose if active
            if (poolParent != null) Destroy(poolParent.gameObject);
            pool?.Dispose();

            // initialize
            poolParent = InstantiatePoolParent().transform;
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
