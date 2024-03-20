using System;
using System.Collections.Generic;

namespace MystiCorp.Runtime.Common.Registration
{
    public class Registrar<TEntity> : IRegistrar<TEntity>
    {
        protected List<TEntity> Entities { get; }
        IEnumerable<TEntity> IRegistrar<TEntity>.Entities => Entities;

        public Registrar()
        {
            Entities = new List<TEntity>();
        }

        public event Action<TEntity> Registered;
        public event Action<TEntity> Deregistered;
        
        public virtual void Register(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (Entities.Contains(entity))
            {
                return;
            }
            
            Entities.Add(entity);
            Registered?.Invoke(entity);
        }

        public virtual void Deregister(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            if (!Entities.Contains(entity))
            {
                return;
            }
            
            Entities.Remove(entity);
            Deregistered?.Invoke(entity);
        }
    }
}
