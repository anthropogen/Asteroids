using UnityEngine;

namespace Asteroids.Model
{
    public class Ufo : Transformable, IUpdatable
    {
        private readonly float speed;
        private readonly Ship ship;
        public Ufo(Vector2 position, Quaternion rotation, float speed, Ship ship) : base(position, rotation)
        {
            this.speed = speed;
            this.ship = ship;
        }

        public void OnUpdate(float timeDeltaTime)
        {
            var direction = (ship.Position - Position).normalized;
            LookAtShip();
            MoveTo(Position + direction * speed * timeDeltaTime);
        }
        private void LookAtShip()
        {
            Vector2 targ = ship.Position;
            targ.x -= Position.x;
            targ.y -= Position.y;
            float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
            Rotate(Quaternion.Euler(new Vector3(0,0,angle)));
        }
    }
}
