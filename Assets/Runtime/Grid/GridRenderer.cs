using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MystiCorp.Runtime
{
    public class GridRenderer : MonoBehaviour
    {
        [Header("Styling")]
        [SerializeField]
        private float spacing;
        [SerializeField]
        private Vector2Int cellExtents;
        [Header("References")]
        [SerializeField]
        private GridData gridData;
        [SerializeField]
        private MeshFilter meshFilter;
        [SerializeField]
        private MeshRenderer meshRenderer;

        private void Update()
        {
            GenerateMesh();
        }

        private void GenerateMesh()
        {
            var triangles = new List<int>();
            var vertices = new List<Vector3>();

            Vector2 topRight    = gridData.CellSize / 2f - Vector2.one * spacing / 2f,
                    topLeft     = new(-topRight.x, topRight.y),
                    bottomRight = new(topRight.x, -topRight.y),
                    bottomLeft  = -topRight;

            Vector2Int start = gridData.WorldToGridPoint(transform.position) - cellExtents / 2;
            Vector2Int position = start;

            int index = 0;

            for (int x = 0; x < cellExtents.x; x++)
            {
                for (int y = 0; y < cellExtents.y; y++)
                {
                    Vector2 center = gridData.GridToWorldPoint(position) - (Vector2)transform.position;

                    vertices.Add(center + bottomLeft);
                    vertices.Add(center + topLeft);
                    vertices.Add(center + topRight);
                    vertices.Add(center + bottomRight);

                    triangles.Add(index + 0);
                    triangles.Add(index + 1);
                    triangles.Add(index + 2);

                    triangles.Add(index + 0);
                    triangles.Add(index + 2);
                    triangles.Add(index + 3);

                    index += 4;

                    position.y++;
                }

                position.x++;
                position.y = start.y;
            }

            meshFilter.mesh = new()
            {
                name = "Grid Mesh",
                vertices = vertices.ToArray(),
                triangles = triangles.ToArray(),
            };
        }
    }
}
