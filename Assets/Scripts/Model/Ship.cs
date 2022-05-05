using UnityEngine;

namespace Asteroids.Model
{
    public class Ship : Transformable, IUpdatable
    {
        private float speedMovementMax;
        private float speedTurnMax;
        private Vector2 input;
        public Ship(Vector3 position, Quaternion rotation, float speedMovement, float speedTurn) : base(position, rotation)
        {
            this.speedMovementMax = ValidateSpeed(speedMovement);
            this.speedTurnMax = ValidateSpeed(speedTurn);
        }

        public void OnUpdate(float timeDeltaTime)
        {
            Vector2 desiredVelocity = input * speedMovementMax * timeDeltaTime;
            Vector2 position = Position + desiredVelocity;
            MoveTo(position);
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
