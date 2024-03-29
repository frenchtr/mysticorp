using System.Collections.Generic;
using System.Linq;
using MystiCorp.Runtime.Common.ScriptableVariables;
using UnityEngine;
using MystiCorp.Runtime.Common;

namespace MystiCorp.Runtime.Magic
{
    [CreateAssetMenu(menuName = "Scriptables/Services/Magic Manager")]
    public class MagicManager : GameManager.GameServiceManager.Service
    {
        [SerializeField]
        private FloatVariable magicAmount;
        [SerializeField]
        private FloatVariable magicPerSecond;
        [SerializeField]
        private float magicPerSecondCalculationDuration;

        private List<(float value, float time)> magicPerSecondValues = new();

        private float magicValueDelta;

        protected override void Start()
        {
            magicAmount.Value = 0;

            magicAmount.ValueChanged += MagicAmountChanged;
        }

        private void MagicAmountChanged(ValueChangedArgs<float> args)
        {
            float delta = args.To - args.From;

            if (delta < 0) return;

            magicValueDelta += delta;
        }

        protected override void LateUpdate()
        {
            magicPerSecondValues.Add((magicValueDelta / Time.deltaTime, Time.time));
            magicValueDelta = 0;

            magicPerSecondValues.RemoveAll(magicValue => Time.time - magicValue.time > magicPerSecondCalculationDuration);

            magicPerSecond.Value = magicPerSecondValues.Select(value => value.value).Sum() / magicPerSecondValues.Count;
        }
    }
}
