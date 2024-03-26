using System.Collections.Generic;
using System.Linq;
using MystiCorp.Runtime.Common.ScriptableVariables;
using UnityEngine;

namespace MystiCorp.Runtime.Magic
{
    [CreateAssetMenu(menuName = "Services/Magic Manager")]
    public class MagicManager : GameManager.GameServiceManager.Service
    {
        [SerializeField]
        private FloatVariable magicAmount;
        [SerializeField]
        private FloatVariable magicPerSecond;
        [SerializeField]
        private float magicPerSecondCalculationDuration;

        private float previousMagicAmount;

        private List<(float value, float time)> magicPerSecondValues = new();

        protected override void LateUpdate()
        {
            float magicDelta = magicAmount.Value - previousMagicAmount;
            previousMagicAmount = magicAmount.Value;

            magicPerSecondValues.Add((magicDelta / Time.deltaTime, Time.time));

            magicPerSecondValues.RemoveAll(magicValue => Time.time - magicValue.time > magicPerSecondCalculationDuration);

            magicPerSecond.Value = magicPerSecondValues.Select(value => value.value).Sum() / magicPerSecondValues.Count;
        }
    }
}
