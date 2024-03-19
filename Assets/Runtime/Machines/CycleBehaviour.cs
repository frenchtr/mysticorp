using System.Collections;
using MystiCorp.Runtime.Common.ScriptableEvents;
using UnityEngine;
using Attribute = TravisRFrench.Attributes.Runtime.Attribute;

namespace MystiCorp.Runtime.Machines
{
    public class CycleBehaviour : MonoBehaviour
    {
        [Header("Magnitude")]
        [Tooltip("How potent should the effects of this entity be?")]
        [SerializeField]
        private float baseMagnitude = 1f;
        [Tooltip("The multiplier which effects the calculated Magnitude.")]
        [SerializeField]
        private Attribute magnitudeMultiplier;
        [Header("Cycle Time")]
        [Tooltip("How many times does this entity activate per second?")]
        [SerializeField]
        private float baseCycleTime = 1f;
        [Tooltip("The multiplier which effects the calculated CylceTime.")]
        [SerializeField]
        private Attribute cycleTimeMultiplier;
        [Header("Events")]
        [SerializeField]
        private GameObjectEvent cycledEvent;

        public float Magnitude => baseMagnitude * MagnitudeMultiplier.ModifiedValue;
        public float CycleTime => baseCycleTime * CycleTimeMultiplier.ModifiedValue;

        public Attribute MagnitudeMultiplier
        {
            get => magnitudeMultiplier;
            private set => magnitudeMultiplier = value;
        }
        
        public Attribute CycleTimeMultiplier
        {
            get => cycleTimeMultiplier;
            private set => cycleTimeMultiplier = value;
        }

        public void ForceRecalculateAll()
        {
            MagnitudeMultiplier?.ForceRecalculateModifiedValue();
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
