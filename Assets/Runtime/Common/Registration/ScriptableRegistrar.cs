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
        
        public IEnumerable<TEntity> Entities => ((IRegistrar<TEntity>)registrar).Entities;

        public event Action<TEntity> Registered
        {
            add => registrar.Registered += value;
            remove => registrar.Registered -= value;
        }
        public event Action<TEntity> Deregistered
        {
            add => registrar.Deregistered += value;
            remove => registrar.Deregistered -= value;
        }

        public override void Setup()
        {
            registrar = new Registrar<TEntity>();
        }

        public virtual void Register(TEntity entity) => registrar.Register(entity);
        public virtual void Deregister(TEntity entity) => registrar.Deregister(entity);
    }
}
