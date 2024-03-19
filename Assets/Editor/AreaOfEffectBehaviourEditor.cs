using MystiCorp.Runtime;
using MystiCorp.Runtime.Common;
using MystiCorp.Runtime.Machines;
using UnityEditor;
using UnityEngine;

namespace MystiCorp.Editor
{
    [CustomEditor(typeof(AreaOfEffectBehaviour))]
    public class AreaOfEffectBehaviourEditor : UnityEditor.Editor
    {
        private void OnSceneGUI()
        {
            var areaOfEffectBehaviour = (AreaOfEffectBehaviour)this.target;
            var transform = areaOfEffectBehaviour.transform;
            var position = transform.position;
            var fieldOfView = areaOfEffectBehaviour.FieldOfView;
            var radius = areaOfEffectBehaviour.Radius;
            var direction = Quaternion.AngleAxis(-(fieldOfView / 2f), -transform.forward) * transform.up;
            var thickness = 4f;
            var color = new Color()
            {
                r = 1f,
                g = 0.92f,
                b = 0.016f,
                a = 0.15f,
            };

            Handles.color = color;
            Handles.DrawSolidArc(
                position, 
                -transform.forward, 
                direction, 
                fieldOfView, 
                radius);

            Handles.color = new Color()
            {
                r = color.r,
                g = color.g,
                b = color.b,
                a = 1f,
            };
            Handles.DrawWireArc(
                position, 
                -transform.forward, 
                direction,
                fieldOfView, 
                radius,
                thickness);
        }
    }
}
