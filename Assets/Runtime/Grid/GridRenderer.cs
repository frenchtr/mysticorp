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
        [SerializeField]
        private Material material;

        [Header("References")]
        [SerializeField]
        private GridData gridData;
        [SerializeField]
        private MeshFilter meshFilter;
        [SerializeField]
        private MeshRenderer meshRenderer;

        private List<Collider2D> highlightColliders;
        private List<Material> highlightMaterials;

        public void AddHighlight(Collider2D collider, Material material)
        {
            highlightColliders.Add(collider);
            highlightMaterials.Add(material);
        }

        public void RemoveSubGrid(Collider2D collider)
        {
            int index = highlightColliders.IndexOf(collider);

            if (index == -1) return;

            highlightColliders.RemoveAt(index);
            highlightMaterials.RemoveAt(index + 1);
        }

        private void Awake()
        {
            highlightColliders = new();
            highlightMaterials = new() { material };

            meshFilter.mesh = new()
            {
                name = "Grid Mesh",
            };
        }

        private void Update()
        {
            GenerateMesh();
        }

        private void GenerateMesh()
        {
            var vertices = new List<Vector3>();
            var triangles = new List<int>[highlightColliders.Count + 1];
            for (int i = 0; i < triangles.Length; i++)
            {
                triangles[i] = new();
            }

            Vector3 topRight    = gridData.CellSize / 2f - Vector2.one * spacing / 2f,
                    topLeft     = new(-topRight.x, topRight.y),
                    bottomRight = new(topRight.x, -topRight.y),
                    bottomLeft  = -topRight;

            Vector2Int start = gridData.WorldToGridPoint(transform.position) - cellExtents / 2;
            Vector2Int position = start;

            for (int x = 0; x < cellExtents.x; x++)
            {
                for (int y = 0; y < cellExtents.y; y++)
                {
                    Vector3 worldCenter = gridData.GridToWorldPoint(position);

                    position.y++;

                    Vector3 localCenter = worldCenter - transform.position;
                    vertices.AddRange(new[]
                    {
                        localCenter + bottomLeft,
                        localCenter + topLeft,
                        localCenter + topRight,
                        localCenter + bottomRight,
                    });

                    int subMesh = 1 + highlightColliders.FindIndex(collider => collider.OverlapPoint(worldCenter));
                    int index = vertices.Count - 4;

                    triangles[subMesh].AddRange(new[]
                    {
                        index + 0,
                        index + 1,
                        index + 2,

                        index + 0,
                        index + 2,
                        index + 3,
                    });
                }

                position.x++;
                position.y = start.y;
            }

            meshRenderer.SetMaterials(highlightMaterials);

            var mesh = meshFilter.mesh;

            mesh.Clear();
            mesh.subMeshCount = triangles.Length;
            mesh.SetVertices(vertices);
            for (int i = 0; i < triangles.Length; i++)
            {
                mesh.SetTriangles(triangles[i], i);
            }

        }
    }
}
