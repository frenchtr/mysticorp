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

        private AreaOfEffectBehaviour areaOfEffectBehaviour;
        
        public GameObject CurrentTarget
        {
            get => currentTarget;
            private set => currentTarget = value;
        }

        private void Awake()
        {
            GetDependencies();
        }

        private void Reset()
        {
            GetDependencies();
        }

        private void Update()
        {
            // Probably in the future we want to have this happen at a specified interval rather than every frame since
            // it's unlikely we'll need that level of precision.
            CurrentTarget = GetTarget();
        }

        private GameObject GetTarget()
        {
            var from = transform.position;
            var charactersToEvaluate = areaOfEffectBehaviour
                .GetComponentsInAreaOfEffect<CharacterIdentity>()
                .Where(character => !character.CompareTag("Hero"));

            return charactersToEvaluate
                .OrderBy(character => Vector2.Distance(from, character.transform.position))
                .Select(character => character.gameObject)
                .FirstOrDefault();
        }

        private void GetDependencies()
        {
            if (areaOfEffectBehaviour == null)
            {
                areaOfEffectBehaviour = GetComponent<AreaOfEffectBehaviour>();
            }
        }
    }
}
