using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace MystiCorp.Runtime.UI
{
    public class AutoBalanceGridLayoutGroup : MonoBehaviour
    {
        [SerializeField]
        private GridLayoutGroup gridLayoutGroup;

        private int childCount;

        private void Update()
        {
            int newChildCount = gridLayoutGroup.transform.childCount;

            if (newChildCount != childCount) UpdateGridLayoutGroup();

            childCount = gridLayoutGroup.transform.childCount;
        }

        private void UpdateGridLayoutGroup()
        {
            int children = 0;

            foreach (RectTransform child in transform)
            {
                if (child.TryGetComponent(out LayoutElement element) && element.ignoreLayout) continue;

                children++;
            }

            gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            gridLayoutGroup.constraintCount = Mathf.CeilToInt(Mathf.Sqrt(children));
        }
    }
}
