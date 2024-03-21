using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MystiCorp.Runtime
{
    public class MachinePaletteElement : MonoBehaviour
    {
        [SerializeField]
        private Transform iconParent;

        private MachineData machine;

        public void Initialize(MachineData machine)
        {
            this.machine = machine;

            var icon = Instantiate(machine.iconPrefab);

            icon.transform.parent = iconParent;
            icon.transform.localPosition = Vector2.zero;
        }
    }
}
