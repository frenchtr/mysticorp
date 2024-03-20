using MystiCorp.Runtime.Common.ScriptableEvents;
using UnityEngine;

namespace MystiCorp.Runtime.Damage
{
    [CreateAssetMenu(menuName = "Scriptables/Events/DamageArgs")]
    public class DamageArgsEvent : ScriptableEvent<DamageArgs>
    {
    }
}