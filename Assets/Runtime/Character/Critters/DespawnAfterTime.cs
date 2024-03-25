using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MystiCorp.Runtime
{
    public class DespawnAfterTime : MonoBehaviour
    {
        [SerializeField]
        private float duration;

        private void Start()
        {
            Destroy(gameObject, duration);
        }
    }
}
