using UnityEngine;
using System;
using UnityEngine.Events;

namespace MystiCorp.Runtime.Character.Critters
{
    public class InvokeAfterTime : MonoBehaviour
    {
        [SerializeField]
        private float duration;
        [SerializeField] private UnityEvent action;

        public event Action Action;

        private float timer;

        private void Update()
        {
            timer += Time.deltaTime;

            if (timer > duration)
            {
                Action?.Invoke();
                action.Invoke();
            }
        }
    }
}
