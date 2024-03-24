using UnityEngine;

namespace MystiCorp.Runtime.Bullets
{
    public class TrailBullet : MonoBehaviour
    {
        [SerializeField]
        private LineRenderer line;
        [SerializeField]
        private float width;
        [SerializeField]
        private AnimationCurve widthOverLifetime;
        [SerializeField]
        private float duration;

        private BulletPool pool;
        private float lifetime;

        public void Spawn(Vector2 start, Vector2 end, BulletPool pool)
        {
            line.positionCount = 2;
            line.SetPositions(new Vector3[] { start, end });

            Invoke(nameof(Despawn), duration);

            lifetime = 0;

            this.pool = pool;
        }

        private void Update()
        {
            lifetime += Time.deltaTime;

            float lifetimePercent = lifetime / duration;
            line.widthMultiplier = width * widthOverLifetime.Evaluate(lifetimePercent);
        }

        private void Despawn()
        {
            pool.Despawn(gameObject);
        }
    }
}
