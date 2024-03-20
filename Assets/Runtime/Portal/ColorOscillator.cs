using System.Collections;
using System.Collections.Generic;
using MystiCorp.Runtime.Common.ScriptableVariables;
using UnityEngine;

namespace MystiCorp.Runtime
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ColorOscillator : MonoBehaviour
    {
        [SerializeField]
        private FloatVariable colorChangeSpeed, saturation, value;

        private float hue;
        private new SpriteRenderer renderer;

        private void Awake()
        {
            renderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            hue += colorChangeSpeed.Value * Time.deltaTime;
            hue %= 1;

            renderer.color = Color.HSVToRGB(hue, saturation.Value, value.Value);
        }
    }
}
