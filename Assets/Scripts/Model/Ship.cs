using UnityEngine;

namespace Asteroids.Model
{
    public class Ship : Transformable, IUpdatable
    {
        private float speedMax = 0.05f;
        private Vector2 input;
        private Vector2 velocity;

        public Ship(Vector3 position, Quaternion rotation, float speedMax) : base(position, rotation)
        {
            this.speedMax = ValidateSpeed(speedMax);
        }

        public void OnUpdate(float timeDeltaTime)
        {
            if (input.sqrMagnitude == 0)
            {
                velocity -= velocity * timeDeltaTime;
            }
            else
            {
                velocity += input * speedMax * timeDeltaTime;
                velocity = Vector2.ClampMagnitude(velocity, speedMax);
            }
            MoveTo(Position + velocity);
            input = Vector2.zero;
        }

        public void OnForwardMovement()
        {
            input = Forward;
        }

        public void OnRotate(float axis)
        {
            Quaternion newRotation = Rotation * Quaternion.Euler(0, 0, axis);
            Rotate(newRotation);
        }
        private float ValidateSpeed(float value)
            => Mathf.Clamp(value, 0f, float.MaxValue);
    }
}
