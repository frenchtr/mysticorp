using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace MystiCorp.Runtime.Common.Pooling
{
    public abstract class ObjectPoolService : ScriptableObject
    {
        [SerializeField]
        protected Poolable prefab;

        private Transform poolParent;
        private ObjectPool<Poolable> pool;
        private List<Poolable> activeObjects;

        protected virtual GameObject PoolParentGameObject => new();

        protected List<Poolable> ActiveObjects
        {
            get
            {
                if (activeObjects == null) InitializePool();
                return activeObjects;
            }
        }

        protected Poolable Spawn()
        {
            if (pool == null || poolParent == null) InitializePool();

            var poolable = pool.Get();

            ActiveObjects.Add(poolable);

            poolable.Despawned += () => Despawn(poolable);

            return poolable;
        }

        protected void Despawn(Poolable poolable)
        {
            poolable.gameObject.SetActive(false);

            ActiveObjects.Remove(poolable);

            pool.Release(poolable);
        }

        private void InitializePool()
        {
            // dispose if active
            if (poolParent != null) Destroy(poolParent.gameObject);
            activeObjects?.ForEach(obj => Destroy(obj));
            pool?.Clear();
            pool?.Dispose();

            // initialize
            poolParent = PoolParentGameObject.transform;
            poolParent.name = name;
            poolParent.gameObject.AddComponent<PoolParent>().Initialize(this);

            activeObjects = new();
            pool = new(
                createFunc: CreateObject,
                actionOnDestroy: DestroyObject);
        }

        protected virtual Poolable CreateObject()
        {
            return Instantiate(prefab, poolParent);
        }

        protected virtual void DestroyObject(Poolable poolable)
        {
            Destroy(poolable.gameObject);
        }
    }
}
