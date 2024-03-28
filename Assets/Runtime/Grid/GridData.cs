using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MystiCorp.Runtime
{
    [CreateAssetMenu(menuName = "Scriptables/Grid Data")]
    public class GridData : ScriptableObject
    {
        [SerializeField]
        private Vector2 cellSize;
        [SerializeField]
        private Vector2 worldSpaceOffset;

        public Vector2 CellSize => cellSize;

        public Vector2 WorldSpaceOffset => worldSpaceOffset;

        public Vector2Int WorldToGridPoint(Vector2 point)
        {
            Vector2 gridPoint = (point - worldSpaceOffset) / cellSize;
            Vector2Int rounded = new(
                Mathf.RoundToInt(gridPoint.x),
                Mathf.RoundToInt(gridPoint.y));

            return rounded;
        }

        public Vector2 GridToWorldPoint(Vector2Int point)
        {
            return point * cellSize + worldSpaceOffset;
        }
    }
}
