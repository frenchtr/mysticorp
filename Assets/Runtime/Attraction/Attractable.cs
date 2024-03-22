using System;
using UnityEngine;

namespace MystiCorp.Runtime.Attraction
{
    public class Attractable : MonoBehaviour
    {
        private float time;
        [SerializeField]
        private float duration = 2f;
        [SerializeField]
        private AnimationCurve curve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
        private Attractor attractor;
        private Vector2 from;
        private Vector2 to;
        
        public bool IsAttracting { get; private set; }
        public bool HasArrived { get; private set; }

        public float Duration
        {
            get => duration;
            set => duration = value;
        }
        public AnimationCurve Curve
        {
            get => curve;
            set => curve = value;
        }

        public event Action Arrived;

        public void AttractTo(Attractor attractor)
        {
            IsAttracting = true;
            this.attractor = attractor;
            from = transform.position;
            to = attractor.transform.position;
        }

        public void StopAttracting()
        {
            IsAttracting = false;
            attractor = null;
        }

        private void Update()
        {
            if (IsAttracting && attractor != null)
            {
                var increment = time + Time.deltaTime;
                time = Mathf.Clamp(increment, 0f, Duration);

                if (increment > Duration)
                {
                    HasArrived = true;
                    IsAttracting = false;
                    Arrived?.Invoke();
                }

                var percentage = Curve.Evaluate(time);
                transform.position = Vector2.Lerp(from, to, percentage);
            }
            
        }
    }
}
