using Asteroids.Model;
using Asteroids.Presenter;
using UnityEngine;

namespace Asteroids.Core
{
    public class GameFactory : MonoBehaviour
    {
        [SerializeField] private ShipPresenter shipTemplate;
        [SerializeField] private ProjectilePresenter bulletTemplate;
        [SerializeField] private ProjectilePresenter laserTemplate;
        private ShipPresenter shipPresenter;
        public void CreateShip()
        {
            if (shipPresenter != null)
                return;
            shipPresenter = Instantiate<ShipPresenter>(shipTemplate);
            Ship ship = new Ship(Vector3.zero, Quaternion.identity, 0.05f);
            shipPresenter.Init(ship);
            shipPresenter.InitShip(new ShipInput(), this);
        }

        public void GetBulletAt(Vector2 position, Quaternion rotation)
        {
            var bullet = Instantiate(bulletTemplate, position, rotation);
            bullet.Init(new Projectile(position, rotation, 10, 3, true));
        }

        public void GetLaserAt(Vector2 position, Quaternion rotation, Transform parent)
        {
            var bullet = Instantiate(laserTemplate, position, rotation, parent);
            bullet.Init(new Projectile(position, rotation, 0, 1, false));
        }

    }
}