using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MystiCorp.Runtime.Common.Pooling
{
    public class PoolParent : MonoBehaviour
    {
        private ObjectPoolService pool;

        public void Initialize(ObjectPoolService pool) => this.pool = pool;

        #region Editor
        #if UNITY_EDITOR

        [CustomEditor(typeof(PoolParent))]
        private class PoolParentEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                var poolParent = target as PoolParent;

                GUI.enabled = false;
                EditorGUILayout.ObjectField("Pool", poolParent.pool, poolParent.pool.GetType(), false);
                GUI.enabled = true;
            }
        }

        #endif
        #endregion
    }
}
