using System.Collections;
using MystiCorp.Runtime.Common.ScriptableEvents;
using UnityEngine;
using Attribute = TravisRFrench.Attributes.Runtime.Attribute;

namespace MystiCorp.Runtime.Machines
{
    public class CycleBehaviour : MonoBehaviour
    {
        [Tooltip("How many times does this entity activate per second?")]
        [SerializeField]
        private float baseCycleTime = 1f;
        [Tooltip("The multiplier which effects the calculated CycleTime.")]
        [SerializeField]
        private Attribute cycleTimeMultiplier = new() { BaseValue = 1 };
        [Header("Events")]
        [SerializeField]
        private GameObjectEvent cycledEvent;

        public float CycleTime => baseCycleTime * CycleTimeMultiplier.ModifiedValue;
        
        public Attribute CycleTimeMultiplier
        {
            get => cycleTimeMultiplier;
            private set => cycleTimeMultiplier = value;
        }

        public void ForceRecalculateAll()
        {
            CycleTimeMultiplier?.ForceRecalculateModifiedValue();
        }

        private void OnEnable()
        {
            StartCoroutine(WaitForNextCycle());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private void OnValidate()
        {
            ForceRecalculateAll();
        }

        private IEnumerator WaitForNextCycle()
        {
            yield return new WaitForSeconds(CycleTime);
            Cycle();
            yield return WaitForNextCycle();
        }

        private void Cycle()
        {
            cycledEvent.Raise(gameObject);
        }
    }
}
