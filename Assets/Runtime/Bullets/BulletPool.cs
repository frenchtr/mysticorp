using MystiCorp.Runtime.Common.Pooling;
using UnityEngine;

namespace MystiCorp.Runtime.Bullets
{
    [CreateAssetMenu(menuName = "Scriptables/Pools/Bullet")]
    public class BulletPool : ObjectPoolService
    {
        public void Spawn(Vector2 start, Vector2 end)
        {
            var bullet = GetObject().GetComponent<TrailBullet>();

            bullet.Spawn(start, end, this);
            bullet.gameObject.SetActive(true);
        }
    }
}
