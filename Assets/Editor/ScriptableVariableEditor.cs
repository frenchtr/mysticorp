using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using MystiCorp.Runtime.Common.ScriptableVariables;

namespace MystiCorp.Editor
{
    [CustomEditor(typeof(ScriptableVariable<>), true)]
    public class ScriptableVariableEditor : UnityEditor.Editor
    {
        private const string ValueFieldName = "Value";

        public override void OnInspectorGUI()
        {
            var value = target
                .GetType()
                .GetProperty("Value")
                .GetValue(target);

            GUI.enabled = false;

            switch (value)
            {
                case float f:
                    EditorGUILayout.FloatField(ValueFieldName, f);
                    break;

                case Object o:
                    EditorGUILayout.ObjectField(ValueFieldName, o, o.GetType(), false);
                    break;
            }

            GUI.enabled = true;
        }
    }
}
