using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MystiCorp.Runtime
{
    public class Draggable : MonoBehaviour
    {
        private new Camera camera;

        private Vector2 dragOffset;
        private System.Action actionOnRelease;

        private Vector2 mousePosition => camera.ScreenToWorldPoint(Input.mousePosition);

        private void Awake()
        {
            camera = FindObjectOfType<Camera>();
        }

        public static void Drag(Transform drag, System.Action actionOnRelease = null) => new GameObject("Draggable").AddComponent<Draggable>().Initialize(drag, actionOnRelease);

        private void Initialize(Transform drag, System.Action actionOnRelease)
        {
            drag.SetParent(transform, true);
            this.actionOnRelease = actionOnRelease;
            dragOffset = (Vector2)transform.position - mousePosition;
        }

        private void Update()
        {
            transform.position = mousePosition + dragOffset;

            if (Input.GetMouseButtonUp(0))
            {
                transform.DetachChildren();
                actionOnRelease?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
