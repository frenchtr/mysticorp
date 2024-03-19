using MystiCorp.Runtime.Common.Registration;
using UnityEngine;

namespace MystiCorp.Runtime.Character
{
    [CreateAssetMenu(menuName = "Scriptables/Registrars/Character Identity")]
    public class CharacterRegistrar : ScriptableRegistrar<CharacterIdentity>
    {
    }
}
