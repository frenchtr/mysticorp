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

        private float cycleTimer;

        public Attribute CycleTimeMultiplier
        {
            get => cycleTimeMultiplier;
            private set => cycleTimeMultiplier = value;
        }

        public void ForceRecalculateAll()
        {
            CycleTimeMultiplier?.ForceRecalculateModifiedValue();
        }

        private void Update()
        {
            cycleTimer += Time.deltaTime;

            if (cycleTimer >= CycleTime)
            {
                cycleTimer = 0;

                Cycle();
            }
        }

        private void OnValidate()
        {
            ForceRecalculateAll();
        }

        private void Cycle()
        {
            cycledEvent.Raise(gameObject);
        }
    }
}
