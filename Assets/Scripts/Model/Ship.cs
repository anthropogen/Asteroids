using UnityEngine;

namespace Asteroids.Model
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ship : Transformable, IUpdatable
    {
        private float speedMax = 0.05f;
        private Vector2 input;
        private Vector2 velocity;
        public Gun BulletGun { get; private set; }
        public LaserGun LaserGun { get; private set; }

        public Ship(Vector3 position, Quaternion rotation, float speedMax, Gun gun, LaserGun laser) : base(position, rotation)
        {
            this.speedMax = ValidateLessZero(speedMax);
            BulletGun = gun;
            LaserGun = laser;
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
            LaserGun.TickTimer(timeDeltaTime);
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

    }
}
