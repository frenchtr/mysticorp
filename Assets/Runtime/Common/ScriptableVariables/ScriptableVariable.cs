﻿using UnityEngine;
using MystiCorp.Runtime.Common;

namespace MystiCorp.Runtime.ScriptableVariables
{
    public abstract class ScriptableVariable<TValue> : ScriptableObject
    {
        [SerializeField]
        private TValue value;

        public event System.Action<ValueChangedArgs<TValue>> ValueChanged;

        public TValue Value
        {
            get => value;
            set
            {
                var args = new ValueChangedArgs<TValue>
                {
                    From = this.value,
                    To = value,
                };

                this.value = value;

                ValueChanged?.Invoke(args);
            }
        }
    }
}
