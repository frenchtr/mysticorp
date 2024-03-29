using UnityEngine;

namespace MystiCorp.Runtime.Collectibles
{
    public class Collectible : MonoBehaviour
    {
        [SerializeField]
        private Poolable poolable;

        public void Collect() => poolable.Despawn();
    }
}
