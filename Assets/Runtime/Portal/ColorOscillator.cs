using UnityEngine;

namespace MystiCorp.Runtime.Portal
{
    public class ColorOscillator : MonoBehaviour
    {
        [SerializeField]
        private float colorChangeSpeed = 0.5f, saturation = 0.8f, value = 1;
        [SerializeField]
        private new SpriteRenderer renderer;

        private float hue;

        private void Update()
        {
            hue += colorChangeSpeed * Time.deltaTime;
            hue %= 1;

            renderer.color = Color.HSVToRGB(hue, saturation, value);
        }
    }
}
