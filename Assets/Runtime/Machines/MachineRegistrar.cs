using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MystiCorp.Runtime.Common.Registration;

namespace MystiCorp.Runtime
{
    [CreateAssetMenu(menuName = "Scriptables/Registrars/Machine Identity")]
    public class MachineRegistrar : ScriptableRegistrar<MachineIdentity>
    {
    }
}
