using UnityEngine;
using UnityEngine.UI;

namespace MystiCorp.Runtime.Machine_Placement
{
    public class MachinePaletteElement : MonoBehaviour
    {
        [Header("Icon")]
        [SerializeField]
        private Transform iconParent;
        [SerializeField]
        private string iconSortingLayer;
        [SerializeField]
        private int iconSortingOrder;

        [Header("Dragging")]
        [SerializeField]
        private Button button;

        private MachineData machine;
        private Transform uiIcon;

        public void Initialize(MachineData machine)
        {
            this.machine = machine;

            uiIcon = Instantiate(machine.iconPrefab).transform;

            uiIcon.parent = iconParent;
            uiIcon.localPosition = Vector2.zero;

            foreach (var renderer in uiIcon.GetComponentsInChildren<Renderer>())
            {
                renderer.sortingLayerName = iconSortingLayer;
                renderer.sortingOrder = iconSortingOrder;
            }

            button.onClick.AddListener(BuyMachine);
        }

        private void BuyMachine()
        {
            var icon = Instantiate(machine.iconPrefab);
            icon.transform.position = uiIcon.position;
            Draggable.Drag(icon.transform, () => PlaceMachine(icon));
        }

        private void PlaceMachine(GameObject icon)
        {
            Instantiate(machine.functionalPrefab, icon.transform.position, Quaternion.identity);
            Destroy(icon);
        }
    }
}
