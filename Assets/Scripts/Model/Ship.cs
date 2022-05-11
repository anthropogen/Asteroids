using System;
using UnityEngine;

namespace Asteroids.Model
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ship : Transformable, IUpdatable
    {
        private float speedMax = 0.05f;
        private Vector2 input;
        private Vector2 velocity;
        private Camera cam;
        public Gun BulletGun { get; private set; }
        public LaserGun LaserGun { get; private set; }
        public event Action<float> SpeedChanged;
        public Ship(Vector3 position, Quaternion rotation, float speedMax, Gun gun, LaserGun laser, Camera camera) : base(position, rotation)
        {
            this.speedMax = ValidateLessZero(speedMax);
            BulletGun = gun;
            LaserGun = laser;
            cam = camera;
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
            Vector2 nextPosition = Position + velocity;
            MoveTo(KeepShipPositionOnScreen(nextPosition));
            SpeedChanged?.Invoke(velocity.magnitude);
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
        private Vector3 KeepShipPositionOnScreen(Vector2 position)
        {
            Vector2 viewPortPos = cam.WorldToViewportPoint(position);
            viewPortPos.x = Mathf.Repeat(viewPortPos.x, 1);
            viewPortPos.y = Mathf.Repeat(viewPortPos.y, 1);
            return cam.ViewportToWorldPoint(viewPortPos);
        }
    }
}
