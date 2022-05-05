using System;
using UnityEngine;

namespace Asteroids.Model
{
    public class Transformable
    {
        public event Action<Vector3> PositionChanged;
        public event Action<Quaternion> RotationChanged;
        public event Action Destoyed;
        public Vector2 Position { get; private set; }
        public Quaternion Rotation { get; private set; }
        public Vector2 Forward => Rotation * Vector3.up;
        public Transformable(Vector2 position, Quaternion rotation)
        {
            Position = position;
            Rotation = rotation;
        }
        public void MoveTo(Vector3 newPosition)
        {
            Position = newPosition;
            PositionChanged?.Invoke(Position);
        }
        public void Rotate(Quaternion newRotation)
        {
            Rotation = newRotation;
            RotationChanged?.Invoke(Rotation);
        }
        public void Destroy()
            => Destoyed?.Invoke();
    }
}
