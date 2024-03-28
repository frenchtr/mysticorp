using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using OliverBeebe.UnityUtilities.Runtime;

namespace MystiCorp.Runtime.Damage
{
    public class DamageText : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI textMesh;
        [SerializeField]
        private SmartCurve spawnAnimation;

        public event System.Action BehaviourComplete;

        public void Initialize(float value)
        {
            textMesh.text = $"{value}";

            StartCoroutine(Behaviour());
        }

        private IEnumerator Behaviour()
        {
            spawnAnimation.Start();
            while (!spawnAnimation.Done)
            {
                float percent = spawnAnimation.Evaluate();

                transform.position += Vector3.up * spawnAnimation.Derivative(1) * Time.deltaTime;

                var color = textMesh.color;
                color.a = Mathf.Lerp(1, 0, percent);
                textMesh.color = color;

                yield return null;
            }

            BehaviourComplete?.Invoke();
            BehaviourComplete = null;
        }
    }
}
