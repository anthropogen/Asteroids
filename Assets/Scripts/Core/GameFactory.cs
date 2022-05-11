using Asteroids.Model;
using Asteroids.Presenter;
using System;
using System.Collections.Generic;
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
        [SerializeField] private UIShipPresenter uiShipPresenterTemplate;
        [SerializeField] private FinishUIPresenter finishUiPresenterTemplate;
        [SerializeField] private GameConfig gameConfig;
        private UIShipPresenter uiShipPresenter;
        private Ship ship;
        private LinkedList<EnemyPresenter> enemies = new LinkedList<EnemyPresenter>();
        public event Action ShipDestroyed;
        public event Action EnemyDestroyed;

        public Ship CreateShip(ShipInput input)
        {
            var shipPresenter = Instantiate(shipTemplate);
            LaserGun laser = new LaserGun(gameConfig.MaxBullets, gameConfig.TimeLaserRestoring);
            ship = new Ship(Vector3.zero, Quaternion.identity, gameConfig.ShipSpeed, new Gun(), laser, Camera.main);
            uiShipPresenter = CreateShipUIPresenter(ship);
            shipPresenter.Init(ship);
            shipPresenter.InitShip(input, this);
            return ship;
        }

        public void CreateFinishUI(int enemyDestroyed)
        {
            var finishUI = Instantiate(finishUiPresenterTemplate);
            finishUI.Init(enemyDestroyed);
        }

        public void CreateUfoAt(Vector2 position)
        {
            var ufo = Instantiate(ufoTemplates[Random.Range(0, ufoTemplates.Length)], position, Quaternion.identity);
            ufo.Init(new Ufo(position, Quaternion.identity, gameConfig.UfoSpeed, ship));
            ufo.ShipDestoyed += OnShipDestoyed;
            ufo.Destroyed += OnEnemyDestroyed;
            enemies.AddLast(ufo);
        }
        public void CreateBigAsteroid(Vector2 position, Vector2 direction)
        {
            var asteroid = Instantiate(bigAsterodsTemplate[Random.Range(0, bigAsterodsTemplate.Length)], position, Quaternion.identity);
            asteroid.Init(new Asteroid(position, Quaternion.identity, direction, gameConfig.AsteroidSpeed, true));
            asteroid.Destroyed += OnEnemyDestroyed;
            asteroid.ShipDestoyed += OnShipDestoyed;
            enemies.AddLast(asteroid);
        }

        private void OnEnemyDestroyed(Vector2 position, EnemyPresenter enemy)
        {
            if (enemy.Model is Asteroid)
            {
                var asteroid = enemy.Model as Asteroid;
                if (asteroid.IsDestroyable)
                    CreateDerbisAsteroid(position);
            }
            enemy.Destroyed -= OnEnemyDestroyed;
            enemy.ShipDestoyed -= OnShipDestoyed;
            enemies.Remove(enemy);
            EnemyDestroyed?.Invoke();
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
        private void CreateDerbisAsteroid(Vector2 position)
        {
            for (int i = 0; i < Random.Range(3, 5); i++)
            {
                var derbis = Instantiate(derbisTemplate[Random.Range(0, bigAsterodsTemplate.Length)], position, Quaternion.identity);
                var direction = ((position + Random.insideUnitCircle) - position).normalized;
                derbis.Init(new Asteroid(position, Quaternion.identity, direction, gameConfig.AsteroidSpeed, false));
                derbis.ShipDestoyed += OnShipDestoyed;
                derbis.Destroyed += OnEnemyDestroyed;
                enemies.AddLast(derbis);
            }
        }

        private UIShipPresenter CreateShipUIPresenter(Ship ship)
        {
            var presenter = Instantiate(uiShipPresenterTemplate);
            presenter.Init(ship);
            return presenter;
        }
        private void OnShipDestoyed()
        {
            foreach (var e in enemies)
            {
                e.Destroyed -= OnEnemyDestroyed;
                e.ShipDestoyed -= OnShipDestoyed;
                Destroy(e.gameObject);
            }
            enemies.Clear();
            Destroy(uiShipPresenter.gameObject);
            ShipDestroyed?.Invoke();
        }
    }
}