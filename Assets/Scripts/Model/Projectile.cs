using UnityEngine;

namespace Asteroids.Model
{
    public class Projectile : Transformable, IUpdatable
    {
        private readonly float speed;
        private readonly float delayDestroy;
        private readonly bool isMovable;
        private float lifeTime;
        public Projectile(Vector2 position, Quaternion rotation, float speed, float delayDestroy, bool isMovable) : base(position, rotation)
        {
            this.speed = ValidateLessZero(speed);
            this.delayDestroy = ValidateLessZero(delayDestroy);
            this.isMovable = isMovable;
        }

        public void OnUpdate(float timeDeltaTime)
        {
            if (lifeTime > delayDestroy)
                Destroy();
            if (isMovable)
                MoveTo(Position + Forward * speed * timeDeltaTime);
            lifeTime += timeDeltaTime;
        }
    }
}
