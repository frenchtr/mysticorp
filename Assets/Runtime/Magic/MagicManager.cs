using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MystiCorp.Runtime.Common;
using System.Linq;

namespace MystiCorp.Runtime
{
    [CreateAssetMenu(menuName = "Services/Magic Manager")]
    public class MagicManager : GameManager.Manager
    {
        [SerializeField]
        private FloatVariable magicAmount;
        [SerializeField]
        private FloatVariable magicPerSecond;
        [SerializeField]
        private float magicPerSecondCalculationDuration;

        private float previousMagicAmount;

        private List<(float value, float time)> magicPerSecondValues = new();

        protected override void Update()
        {
            float magicDelta = magicAmount.Value - previousMagicAmount;
            previousMagicAmount = magicAmount.Value;

            magicPerSecondValues.Add((magicDelta, Time.time));

            magicPerSecondValues.RemoveAll(magicValue => Time.time - magicValue.time > magicPerSecondCalculationDuration);

            magicPerSecond.Value = magicPerSecondValues.Select(value => value.value).Sum() / magicPerSecondValues.Count;
        }
    }
}
