using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MystiCorp.Runtime.Common;

namespace MystiCorp.Runtime
{
    public class MagicAmountDisplay : MonoBehaviour
    {
        [SerializeField]
        private MagicManager magicManager;
        [SerializeField]
        private TextMeshProUGUI amountDisplay;

        private void OnEnable()
        {
            magicManager.MagicAmountChanged += OnMagicAmountChanged;
        }

        private void OnDisable()
        {
            magicManager.MagicAmountChanged -= OnMagicAmountChanged;
        }

        private void OnMagicAmountChanged(ValueChangedArgs<float> args)
        {
            amountDisplay.text = $"{args.To:n}";
        }
    }
}
