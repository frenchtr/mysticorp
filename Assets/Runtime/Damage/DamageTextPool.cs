using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MystiCorp.Runtime.Common.Pooling;

namespace MystiCorp.Runtime.Damage
{
    public readonly struct DamageTextSpawnArgs
    {
        public DamageTextSpawnArgs(float value, Vector2 position)
            => (this.value, this.position) = (value, position);

        public readonly float value;
        public readonly Vector2 position;
    }

    [CreateAssetMenu(menuName = "Scriptables/Pools/Damage Text")]
    public class DamageTextPool : ObjectPoolService
    {
        [SerializeField]
        private GameObject canvasPrefab;

        protected override GameObject PoolParentGameObject => Instantiate(canvasPrefab);

        public void Spawn(DamageTextSpawnArgs spawnArgs)
            => Spawn()
            .GetComponent<DamageText>()
            .Initialize(spawnArgs);
    }
}
