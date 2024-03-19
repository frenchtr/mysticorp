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
        private TextMeshProUGUI amountDisplay;

        private void OnEnable()
        {
            this.magicAmount.ValueChanged += this.OnMagicAmountChanged;
        }

        private void OnDisable()
        {
            this.magicAmount.ValueChanged -= this.OnMagicAmountChanged;
        }

        private void OnMagicAmountChanged(ValueChangedArgs<float> args)
        {
            this.amountDisplay.text = $"{args.To:n}";
        }
    }
}
