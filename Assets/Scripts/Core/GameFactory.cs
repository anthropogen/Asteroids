using Asteroids.Model;
using Asteroids.Presenter;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids.Core
{
    public class GameFactory : MonoBehaviour
    {
        [SerializeField] private ShipPresenter shipTemplate;
        [SerializeField] private ProjectilePresenter bulletTemplate;
        [SerializeField] private ProjectilePresenter laserTemplate;
        [SerializeField] private AsteroidPresenter[] bigAsterodsTemplate;
        [SerializeField] private AsteroidPresenter[] derbisTemplate;
        private ShipPresenter shipPresenter;
        public event Action ShipDestroyed;

        public void CreateShip()
        {
            if (shipPresenter != null)
                return;
            shipPresenter = Instantiate<ShipPresenter>(shipTemplate);
            Ship ship = new Ship(Vector3.zero, Quaternion.identity, 0.05f);
            shipPresenter.Init(ship);
            shipPresenter.InitShip(new ShipInput(), this);
        }

        public void CreateBigAsteroid(Vector2 position, Vector2 direction)
        {
            var asteroid = Instantiate(bigAsterodsTemplate[Random.Range(0, bigAsterodsTemplate.Length)], position, Quaternion.identity);
            asteroid.Init(new Asteroid(position, Quaternion.identity, direction, 3, true));
            asteroid.Destroyed += CreateDerbisAsteroid;
            asteroid.ShipDestoyed += OnShipDestoyed;
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
        private void CreateDerbisAsteroid(Vector2 position, AsteroidPresenter parentAsteroid)
        {
            parentAsteroid.Destroyed += CreateDerbisAsteroid;
            for (int i = 0; i < Random.Range(3, 5); i++)
            {
                var derbis = Instantiate(derbisTemplate[Random.Range(0, bigAsterodsTemplate.Length)], position, Quaternion.identity);
                var direction = ((position + Random.insideUnitCircle) - position).normalized;
                derbis.Init(new Asteroid(position, Quaternion.identity, direction, 3, false));
                derbis.ShipDestoyed += OnShipDestoyed;
            }
        }

        private void OnShipDestoyed()
            => ShipDestroyed?.Invoke();
    }
}