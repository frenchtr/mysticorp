using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MystiCorp.Runtime
{
    public class TrailBullet : MonoBehaviour
    {
        [SerializeField]
        private LineRenderer line;
        [SerializeField]
        private float duration;

        private BulletPool pool;

        public void Spawn(Vector2 start, Vector2 end, BulletPool pool)
        {
            line.positionCount = 2;
            line.SetPositions(new Vector3[] { start, end });

            Invoke(nameof(Despawn), duration);

            this.pool = pool;
        }

        private void Despawn()
        {
            pool.Despawn(gameObject);
        }
    }
}
