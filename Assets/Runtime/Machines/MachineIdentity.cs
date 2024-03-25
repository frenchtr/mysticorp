using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MystiCorp.Runtime
{
    public class MachineIdentity : MonoBehaviour
    {
        [SerializeField]
        private MachineRegistrar registrar;
        [SerializeField]
        private List<SpriteRenderer> renderers;

        public List<SpriteRenderer> Renderers => renderers;

        private void OnEnable()
        {
            registrar.Register(this);
        }

        private void OnDisable()
        {
            registrar.Deregister(this);
        }
    }
}
