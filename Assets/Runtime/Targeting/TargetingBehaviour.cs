using System.Linq;
using MystiCorp.Runtime.Character;
using MystiCorp.Runtime.Machines;
using UnityEngine;

namespace MystiCorp.Runtime.Targeting
{
    [RequireComponent(typeof(AreaOfEffectBehaviour))]
    public class TargetingBehaviour : MonoBehaviour
    {
        [SerializeField]
        private GameObject currentTarget;
        [Header("Dependencies")]
        [SerializeField]
        private CharacterRegistrar registrar;
        [SerializeField]
        private AreaOfEffectBehaviour areaOfEffectBehaviour;
        
        public GameObject CurrentTarget
        {
            get => currentTarget;
            private set => currentTarget = value;
        }

        private void Reset()
        {
            areaOfEffectBehaviour = GetComponent<AreaOfEffectBehaviour>();
        }

        private void Update()
        {
            // Probably in the future we want to have this happen at a specified interval rather than every frame since
            // it's unlikely we'll need that level of precision.
            CurrentTarget = GetTarget();
        }

        private GameObject GetTarget()
        {
            var thisTransform = transform;
            var from = thisTransform.position;
            var charactersToEvaluate = areaOfEffectBehaviour
                .GetGameObjectsInAreaOfEffect()
                .Select(gameObj => gameObj.GetComponent<CharacterIdentity>())
                .Where(character => character != null)
                .Where(character => !character.CompareTag("Hero"));

            return charactersToEvaluate
                .OrderBy(character => Vector2.Distance(from, character.transform.position))
                .Select(character => character.gameObject)
                .FirstOrDefault();
        }
    }
}
