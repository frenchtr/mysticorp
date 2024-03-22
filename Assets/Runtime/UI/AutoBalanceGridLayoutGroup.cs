using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MystiCorp.Runtime
{
    [ExecuteAlways]
    [RequireComponent(typeof(GridLayoutGroup))]
    public class AutoBalanceGridLayoutGroup : MonoBehaviour
    {
        [SerializeField]
        private GridLayoutGroup gridLayoutGroup;

        private int childCount;

        private void Reset()
        {
            GetReferences();
        }

        private void Awake()
        {
            GetReferences();
        }

        private void Update()
        {
            int newChildCount = gridLayoutGroup.transform.childCount;

            if (newChildCount != childCount) UpdateGridLayoutGroup();

            childCount = gridLayoutGroup.transform.childCount;
        }

        private void GetReferences()
        {
            gridLayoutGroup = GetComponent<GridLayoutGroup>();
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

        #region Editor
        #if UNITY_EDITOR

        [CustomEditor(typeof(AutoBalanceGridLayoutGroup))]
        private class AutoBalanceGridLayoutGroupEditor : Editor
        {
            public override void OnInspectorGUI()
            {
            }
        }

        #endif
        #endregion
    }
}
