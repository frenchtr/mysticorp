using UnityEngine;

namespace MystiCorp.Runtime.Common.ScriptableVariables
{
    public abstract class ScriptableVariable<TValue> : ScriptableObject
    {
        [SerializeField]
        private TValue value;

        public event System.Action<ValueChangedArgs<TValue>> ValueChanged;

        public TValue Value
        {
            get => this.value;
            set
            {
                var args = new ValueChangedArgs<TValue>
                {
                    From = this.value,
                    To = value,
                };

                this.value = value;

                this.ValueChanged?.Invoke(args);
            }
        }
    }
}
