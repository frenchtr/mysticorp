using UnityEngine;
using TMPro;
using MystiCorp.Runtime.Common;

namespace MystiCorp.Runtime
{
    public class MagicAmountDisplay : MonoBehaviour
    {
        [SerializeField]
        private FloatVariable magicAmount;
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
            amountDisplay.text = $"{args.To:n}";
        }
    }
}
