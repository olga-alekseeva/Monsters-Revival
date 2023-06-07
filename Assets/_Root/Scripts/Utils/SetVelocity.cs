using Abstractions.Basics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    internal sealed class SetVelocity
    {
        private Vector3 _velocity;
        private Transform _transform;

        public SetVelocity(Vector3 velocity, Transform transform)
        {
            _velocity = velocity;
            _transform = transform;
            float angle = Vector3.Angle(Vector3.left, _velocity);
            Vector3 axis = Vector3.Cross(Vector3.left, _velocity);
            _transform.transform.rotation = Quaternion.AngleAxis(angle, axis);
        }
        public void Update()
        {
            _transform.position = _velocity;
        }

    }
}
