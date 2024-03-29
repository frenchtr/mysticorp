using MystiCorp.Runtime.Common.Pooling;
using UnityEngine;

namespace MystiCorp.Runtime.Bullets
{
    public readonly struct BulletSpawnArgs
    {
        public BulletSpawnArgs(Vector2 start, Vector2 end)
            => (this.start, this.end) = (start, end);

        public readonly Vector2 start;
        public readonly Vector2 end;
    }

    [CreateAssetMenu(menuName = "Scriptables/Pools/Bullet")]
    public class BulletPool : ObjectPoolService
    {
        public void Spawn(BulletSpawnArgs spawnArgs)
            => Spawn()
            .GetComponent<TrailBullet>()
            .Spawn(spawnArgs);
    }
}
