using UnityEngine;

namespace MystiCorp.Runtime.Character
{
    public class CharacterIdentity : MonoBehaviour
    {
        [SerializeField]
        private CharacterRegistrar registrar;
        
        private void OnEnable()
        {
            this.registrar.Register(this);
        }

        private void OnDisable()
        {
            this.registrar.Deregister(this);
        }
    }
}
