using System.Collections.Generic;
using MystiCorp.Runtime.Common.Registration;
using UnityEngine;

namespace MystiCorp.Runtime
{
    public class RegistrarManager : MonoBehaviour
    {
        [SerializeField]
        private List<ScriptableRegistrar> registrars;

        private void Awake()
        {
            foreach (var registrar in registrars)
            {
                registrar.Setup();
            }
        }
    }
}
