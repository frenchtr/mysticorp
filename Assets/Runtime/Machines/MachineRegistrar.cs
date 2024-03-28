using MystiCorp.Runtime.Common.Registration;
using UnityEngine;

namespace MystiCorp.Runtime.Machines
{
    [CreateAssetMenu(menuName = "Scriptables/Registrars/Machine Identity")]
    public class MachineRegistrar : ScriptableRegistrar<MachineIdentity>
    {
    }
}
