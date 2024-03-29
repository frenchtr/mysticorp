using UnityEngine;

namespace MystiCorp.Runtime.Character.Critters
{
    public class DespawnAfterTime : MonoBehaviour
    {
        [SerializeField]
        private float duration;
        [SerializeField]
        private Poolable poolable;

        private float timer;

        private void Awake()
        {
            poolable.Spawned += () => timer = 0;
        }

        private void Update()
        {
            timer += Time.deltaTime;

            if (timer > duration)
            {
                poolable.Despawn();
            }
        }
    }
}
