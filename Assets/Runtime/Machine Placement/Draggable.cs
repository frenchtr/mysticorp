using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MystiCorp.Runtime
{
    public class Draggable : MonoBehaviour
    {
        private new Camera camera;

        private Vector2 dragOffset;
        private bool dragging;

        private Vector2 mousePosition => camera.ScreenToWorldPoint(Input.mousePosition);

        private void Awake()
        {
            camera = FindObjectOfType<Camera>();
        }

        public void StartDragging()
        {
            dragging = true;

            dragOffset = mousePosition - (Vector2)transform.position;
        }

        private void Update()
        {
            if (!dragging) return;

            transform.position = mousePosition + dragOffset;

            if (Input.GetMouseButtonUp(0))
            {
                dragging = false;
            }
        }
    }
}
