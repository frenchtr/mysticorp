using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MystiCorp.Runtime
{
    public class OptionsMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject content;

        private bool visible;

        private void Start()
        {
            SetVisibility(false);
        }

        public void ToggleVisibility() => SetVisibility(!visible);

        public void QuitGame() => Application.Quit();

        private void SetVisibility(bool visible)
        {
            this.visible = visible;

            if (visible)
            {
                content.SetActive(true);
            }
            else
            {
                content.SetActive(false);
            }
        }
    }
}
