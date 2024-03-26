using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MystiCorp.Runtime.Common.Pooling;

namespace MystiCorp.Runtime.Damage
{
    [CreateAssetMenu(menuName = "Scriptables/Pools/Damage Text")]
    public class DamageTextPool : ObjectPoolService
    {
        [SerializeField]
        private GameObject canvasPrefab;

        protected override GameObject InstantiatePoolParent() => Instantiate(canvasPrefab);

        public void Spawn(float value, Vector3 position)
        {
            var obj = GetObject();
            obj.SetActive(true);

            obj.transform.position = position;

            var damageText = obj.GetComponent<DamageText>();
            damageText.Initialize(value);
            damageText.BehaviourComplete += () => Despawn(damageText.gameObject);
        }
    }
}
