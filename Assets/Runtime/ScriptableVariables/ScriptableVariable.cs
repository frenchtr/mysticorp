using UnityEngine;

namespace ScringloGames.ColorClash.Runtime.Shared.ScriptableVariables
{
    public abstract class ScriptableVariable<TValue> : ScriptableObject
    {
        public TValue Value { get; set; }
    }
}
