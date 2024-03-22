using System.Collections.Generic;
using UnityEngine;

namespace MystiCorp.Runtime.Machine_Placement
{
    public class MachinePalette : MonoBehaviour
    {
        [SerializeField]
        private List<MachineData> machines;
        [SerializeField]
        private MachinePaletteElement elementPrefab;
        [SerializeField]
        private Transform elementsGridParent;

        private void Start()
        {
            foreach (var machine in machines)
            {
                Instantiate(elementPrefab, elementsGridParent).Initialize(machine);
            }
        }
    }
}
