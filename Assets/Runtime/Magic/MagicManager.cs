using System.Collections.Generic;
using System.Linq;
using MystiCorp.Runtime.Common.ScriptableVariables;
using MystiCorp.Runtime.Game_Manager;
using UnityEngine;

namespace MystiCorp.Runtime.Magic
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
            float magicDelta = this.magicAmount.Value - this.previousMagicAmount;
            this.previousMagicAmount = this.magicAmount.Value;

            this.magicPerSecondValues.Add((magicDelta, Time.time));

            this.magicPerSecondValues.RemoveAll(magicValue => Time.time - magicValue.time > this.magicPerSecondCalculationDuration);

            this.magicPerSecond.Value = this.magicPerSecondValues.Select(value => value.value).Sum() / this.magicPerSecondValues.Count;
        }
    }
}
