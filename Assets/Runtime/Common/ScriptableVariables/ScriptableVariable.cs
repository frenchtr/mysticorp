using UnityEngine;

namespace MystiCorp.Runtime.ScriptableVariables
{
    public abstract class ScriptableVariable<TValue> : ScriptableObject
    {
        [field: SerializeField]
        public TValue Value { get; set; }
    }
}
