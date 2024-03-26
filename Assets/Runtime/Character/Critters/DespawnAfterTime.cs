using UnityEngine;

namespace MystiCorp.Runtime.Character.Critters
{
    public class DespawnAfterTime : MonoBehaviour
    {
        [SerializeField]
        private float duration;

        private void Start()
        {
            Destroy(gameObject, duration);
        }
    }
}
