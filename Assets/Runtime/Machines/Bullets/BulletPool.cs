using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MystiCorp.Runtime
{
    [CreateAssetMenu(menuName = "Services/Pools/Bullet Pool")]
    public class BulletPool : ObjectPoolService
    {
        public void Spawn(Vector2 start, Vector2 end)
        {
            var bullet = GetObject().GetComponent<TrailBullet>();

            bullet.Spawn(start, end, this);
        }
    }
}
