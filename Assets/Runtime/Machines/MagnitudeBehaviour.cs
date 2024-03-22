using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Attribute = TravisRFrench.Attributes.Runtime.Attribute;

namespace MystiCorp.Runtime.Machines
{
    public class MagnitudeBehaviour : MonoBehaviour
    {
        [Tooltip("How potent should the effects of this entity be?")]
        [SerializeField]
        private float baseMagnitude = 1f;
        [Tooltip("The multiplier which effects the calculated Magnitude.")]
        [SerializeField]
        private Attribute magnitudeMultiplier = new() { BaseValue = 1 };

        public float Magnitude => baseMagnitude * MagnitudeMultiplier.ModifiedValue;

        public Attribute MagnitudeMultiplier
        {
            get => magnitudeMultiplier;
            private set => magnitudeMultiplier = value;
        }

        public void ForceRecalculateAll()
        {
            MagnitudeMultiplier?.ForceRecalculateModifiedValue();
        }

        private void OnValidate()
        {
            ForceRecalculateAll();
        }
    }
}
