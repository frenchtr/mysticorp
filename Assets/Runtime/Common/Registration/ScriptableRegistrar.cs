using System;
using System.Collections.Generic;
using UnityEngine;

namespace MystiCorp.Runtime.Common.Registration
{
    public abstract class ScriptableRegistrar : ScriptableObject
    {
        public virtual void Setup()
        {
        }
    }
    
    public abstract class ScriptableRegistrar<TEntity> : ScriptableRegistrar, IRegistrar<TEntity>
    {
        private Registrar<TEntity> registrar;
        private Registrar<TEntity> Registrar => registrar ??= new();

        public IEnumerable<TEntity> Entities => ((IRegistrar<TEntity>)Registrar).Entities;

        public event Action<TEntity> Registered
        {
            add => Registrar.Registered += value;
            remove => Registrar.Registered -= value;
        }
        public event Action<TEntity> Deregistered
        {
            add => Registrar.Deregistered += value;
            remove => Registrar.Deregistered -= value;
        }

        public virtual void Register(TEntity entity) => Registrar.Register(entity);
        public virtual void Deregister(TEntity entity) => Registrar.Deregister(entity);
    }
}
