using System.Collections;
using MystiCorp.Runtime.Common.ScriptableEvents;
using UnityEngine;
using Attribute = TravisRFrench.Attributes.Runtime.Attribute;

namespace MystiCorp.Runtime.Machines
{
    public class CycleBehaviour : MonoBehaviour
    {
        [Tooltip("How potent should the effects of this entity be?")]
        [SerializeField]
        private float baseMagnitude = 1f;
        [Tooltip("How many times does this entity activate per second?")]
        [SerializeField]
        private float baseCycleTime = 1f;
        [Header("Events")]
        [SerializeField]
        private GameObjectEvent cycledEvent;
        
        public float Magnitude => this.baseMagnitude * this.MagnitudeMultiplier.ModifiedValue;
        public float CycleTime => this.baseCycleTime * this.CycleTimeMultiplier.ModifiedValue;

        [field: SerializeField]
        public Attribute MagnitudeMultiplier { get; private set; }
        [field: SerializeField]
        public Attribute CycleTimeMultiplier { get; private set; }

        public void ForceRecalculateAll()
        {
            this.MagnitudeMultiplier?.ForceRecalculateModifiedValue();
            this.CycleTimeMultiplier?.ForceRecalculateModifiedValue();
        }

        private void OnEnable()
        {
            this.StartCoroutine(this.WaitForNextCycle());
        }

        private void OnDisable()
        {
            this.StopAllCoroutines();
        }

        private void OnValidate()
        {
            this.ForceRecalculateAll();
        }

        private IEnumerator WaitForNextCycle()
        {
            yield return new WaitForSeconds(this.CycleTime);
            this.Cycle();
        }

        private void Cycle()
        {
            this.cycledEvent.Raise(this.gameObject);
        }
    }
}
