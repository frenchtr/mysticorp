using System.Collections.Generic;
using UnityEngine;

namespace MystiCorp.Runtime.Common.Registration
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
