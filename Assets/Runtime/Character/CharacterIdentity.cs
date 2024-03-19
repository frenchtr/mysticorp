using UnityEngine;

namespace MystiCorp.Runtime.Character
{
    public class CharacterIdentity : MonoBehaviour
    {
        [SerializeField]
        private CharacterRegistrar registrar;
        
        private void OnEnable()
        {
            registrar.Register(this);
        }

        private void OnDisable()
        {
            registrar.Deregister(this);
        }
    }
}
