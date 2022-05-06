using UnityEngine;

namespace Asteroids.Model
{
    public class Asteroid : Transformable, IUpdatable
    {
        private readonly Vector2 direction;
        private readonly float speed;
        public bool IsDestroyable { get; }
        public Asteroid(Vector2 position, Quaternion rotation, Vector2 direction, float speed, bool isDestroyable) : base(position, rotation)
        {
            this.direction = direction;
            this.speed = speed;
            IsDestroyable = isDestroyable;
        }

        public void OnUpdate(float timeDeltaTime)
            => MoveTo(Position + direction * speed * timeDeltaTime);
    }
}
