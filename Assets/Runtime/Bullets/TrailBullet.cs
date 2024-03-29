using UnityEngine;

namespace MystiCorp.Runtime.Bullets
{
    public class TrailBullet : MonoBehaviour
    {
        [Header("Visuals")]
        [SerializeField]
        private float width;
        [SerializeField]
        private AnimationCurve widthOverLifetime;
        [SerializeField]
        private float duration;

        [Header("References")]
        [SerializeField]
        private LineRenderer line;
        [SerializeField]
        private Poolable poolable;

        private float lifetime;

        public void Spawn(BulletSpawnArgs spawnArgs)
        {
            line.positionCount = 2;
            line.SetPositions(new Vector3[] { spawnArgs.start, spawnArgs.end });
            gameObject.SetActive(true);

            lifetime = 0;
        }

        private void Update()
        {
            lifetime += Time.deltaTime;

            float lifetimePercent = lifetime / duration;
            line.widthMultiplier = width * widthOverLifetime.Evaluate(lifetimePercent);

            if (lifetimePercent > 1)
            {
                poolable.Return();
            }
        }
    }
}
