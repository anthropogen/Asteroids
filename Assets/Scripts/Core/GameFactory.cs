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
        [SerializeField] private EnemyPresenter[] bigAsterodsTemplate;
        [SerializeField] private EnemyPresenter[] derbisTemplate;
        [SerializeField] private EnemyPresenter[] ufoTemplates;
        [SerializeField] private GameConfig gameConfig;
        private ShipPresenter shipPresenter;
        private Ship ship;
        public event Action ShipDestroyed;

        public void CreateShip()
        {
            if (shipPresenter != null)
                return;
            shipPresenter = Instantiate(shipTemplate);
            LaserGun laser = new LaserGun(gameConfig.MaxBullets, gameConfig.TimeLaserRestoring);
            ship = new Ship(Vector3.zero, Quaternion.identity, gameConfig.ShipSpeed, new Gun(), laser);
            shipPresenter.Init(ship);
            shipPresenter.InitShip(new ShipInput(), this);
        }

        public void CreateUfoAt(Vector2 position)
        {
            var ufo = Instantiate(ufoTemplates[Random.Range(0, ufoTemplates.Length)], position, Quaternion.identity);
            ufo.Init(new Ufo(position, Quaternion.identity, gameConfig.UfoSpeed, ship));
            ufo.ShipDestoyed += OnShipDestoyed;
        }
        public void CreateBigAsteroid(Vector2 position, Vector2 direction)
        {
            var asteroid = Instantiate(bigAsterodsTemplate[Random.Range(0, bigAsterodsTemplate.Length)], position, Quaternion.identity);
            asteroid.Init(new Asteroid(position, Quaternion.identity, direction, gameConfig.AsteroidSpeed, true));
            asteroid.Destroyed += CreateDerbisAsteroid;
            asteroid.ShipDestoyed += OnShipDestoyed;
        }

        public void GetBulletAt(Vector2 position, Quaternion rotation)
        {
            var bullet = Instantiate(bulletTemplate, position, rotation);
            bullet.Init(new Projectile(position, rotation, gameConfig.BulletSpeed, gameConfig.DelayBeforeDestroyBullet, true));
        }

        public void GetLaserAt(Vector2 position, Quaternion rotation, Transform parent)
        {
            var bullet = Instantiate(laserTemplate, position, rotation, parent);
            bullet.Init(new Projectile(position, rotation, 0, gameConfig.DelayBeforeDestroyLaser, false));
        }
        private void CreateDerbisAsteroid(Vector2 position, EnemyPresenter parentAsteroid)
        {
            parentAsteroid.Destroyed += CreateDerbisAsteroid;
            for (int i = 0; i < Random.Range(3, 5); i++)
            {
                var derbis = Instantiate(derbisTemplate[Random.Range(0, bigAsterodsTemplate.Length)], position, Quaternion.identity);
                var direction = ((position + Random.insideUnitCircle) - position).normalized;
                derbis.Init(new Asteroid(position, Quaternion.identity, direction, gameConfig.AsteroidSpeed, false));
                derbis.ShipDestoyed += OnShipDestoyed;
            }
        }
        private void OnShipDestoyed()
            => ShipDestroyed?.Invoke();
    }
}