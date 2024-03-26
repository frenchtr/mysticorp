using UnityEngine;

namespace MystiCorp.Runtime.Collectibles
{
    public class Collectible : MonoBehaviour
    {
        public event System.Action Collected;

        public void Collect()
        {
            Collected?.Invoke();
            Collected = null;
        }
    }
}
