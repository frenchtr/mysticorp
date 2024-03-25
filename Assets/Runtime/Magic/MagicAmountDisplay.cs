using MystiCorp.Runtime.Common;
using MystiCorp.Runtime.Common.ScriptableVariables;
using TMPro;
using UnityEngine;

namespace MystiCorp.Runtime.Magic
{
    public class MagicAmountDisplay : MonoBehaviour
    {
        [SerializeField]
        private FloatVariable magicAmount;
        [SerializeField]
        private string suffix;
        [SerializeField]
        private TextMeshProUGUI amountDisplay;

        private void OnEnable()
        {
            magicAmount.ValueChanged += OnMagicAmountChanged;
        }

        private void OnDisable()
        {
            magicAmount.ValueChanged -= OnMagicAmountChanged;
        }

        private void OnMagicAmountChanged(ValueChangedArgs<float> args)
        {
            amountDisplay.text = $"{args.To:n} {suffix}";
        }
    }
}
