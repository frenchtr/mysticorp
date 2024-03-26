using System.Collections.Generic;
using UnityEngine;

namespace MystiCorp.Runtime.Portal
{
    public class Portal : MonoBehaviour
    {
        [SerializeField]
        private List<CritterPool> critterPool;
        [SerializeField]
        private Transform spawnpoint;

        private int level;

        public void Upgrade() => level++;

        private void Update()
        {
            foreach (var pool in critterPool)
            {
                pool.UpdateSpawner(level, spawnpoint);
            }
        }
    }
}
