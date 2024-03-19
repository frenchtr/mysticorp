using UnityEngine;

namespace MystiCorp.Runtime.ScriptableVariables
{
    public abstract class ScriptableVariable<TValue> : ScriptableObject
    {
        public TValue Value { get; set; }
    }
}
