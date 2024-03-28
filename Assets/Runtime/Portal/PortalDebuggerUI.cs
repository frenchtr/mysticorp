using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MystiCorp.Runtime.Portal;

namespace MystiCorp.Runtime
{
    public class PortalDebuggerUI : MonoBehaviour
    {
        [SerializeField]
        private Button increaseButton, decreaseButton;

        private void Start()
        {
            var portal = FindObjectOfType<Portal.Portal>();

            increaseButton.onClick.AddListener(portal.Upgrade);
            decreaseButton.onClick.AddListener(portal.Downgrade);
        }
    }
}
