using MystiCorp.Runtime.Common.ScriptableVariables;
using UnityEngine;

namespace MystiCorp.Runtime.Portal
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ColorOscillator : MonoBehaviour
    {
        [SerializeField]
        private float colorChangeSpeed = 0.5f, saturation = 0.8f, value = 1;

        private float hue;
        private new SpriteRenderer renderer;

        private void Awake()
        {
            GetDependencies();
        }

        private void Reset()
        {
            GetDependencies();
        }

        private void Update()
        {
            hue += colorChangeSpeed * Time.deltaTime;
            hue %= 1;

            renderer.color = Color.HSVToRGB(hue, saturation, value);
        }

        private void GetDependencies()
        {
            if (renderer == null)
            {
                renderer = GetComponent<SpriteRenderer>();
            }
        }
    }
}
