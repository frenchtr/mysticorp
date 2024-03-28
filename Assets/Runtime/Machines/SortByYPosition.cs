using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MystiCorp.Runtime.Machines
{
    public class SortByYPosition : MonoBehaviour
    {
        private static List<SortByYPosition> entities = new();

        private SortByYPosition Instance => instance == null ? instance = this : instance;
        private static SortByYPosition instance;

        private SpriteRenderer[] renderers;

        private void Awake()
        {
            renderers = GetComponentsInChildren<SpriteRenderer>();
        }

        private void OnEnable()
        {
            entities.Add(this);
        }

        private void OnDisable()
        {
            entities.Remove(this);
        }

        private void Update()
        {
            if (Instance == this)
            {
                Sort();
            }
        }

        private void Sort()
        {
            int sortingOrder = 0;

            entities = entities
                .OrderBy(entity => -entity.transform.position.y)
                .ToList();

            foreach (var entity in entities)
            {
                var rends = entity
                    .renderers
                    .OrderBy(rend => rend.sortingOrder);

                foreach (var rend in rends)
                {
                    rend.sortingOrder = sortingOrder;
                    sortingOrder++;
                }
            }
        }
    }
}
