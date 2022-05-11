using Asteroids.Core;
using Asteroids.Model;
using System;
using UnityEngine;

namespace Asteroids.Presenter
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ShipPresenter : Presenter
    {
        [SerializeField] private Transform shootPos;
        private Ship ship;
        private ShipInput shipInput;
        private GameFactory gameFactory;

        public void InitShip(ShipInput shipInput, GameFactory gameFactory)
        {
            if (Model == null)
                throw new NullReferenceException("Ship didn't initialize");
            ship = Model as Ship;
            this.shipInput = shipInput;
            shipInput.Ship.FireBullet.performed += ctx => ship.BulletGun.TryShot();
            shipInput.Ship.FireLaser.performed += ctx => ship.LaserGun.TryShot();
            shipInput.Enable();
            ship.BulletGun.Shoot += CreateBullet;
            ship.LaserGun.Shoot += CreateLaser;
            this.gameFactory = gameFactory;
        }

       

        private void CreateBullet()
            => gameFactory.GetBulletAt(shootPos.position, ship.Rotation);

        private void CreateLaser()
            => gameFactory.GetLaserAt(shootPos.position, ship.Rotation, transform);

        private void OnDestroy()
        {
            if (shipInput != null)
            {
                shipInput.Ship.FireBullet.performed -= ctx => ship.BulletGun.TryShot();
                shipInput.Ship.FireLaser.performed -= ctx => ship.LaserGun.TryShot();
                ship.BulletGun.Shoot -= CreateBullet;
                ship.LaserGun.Shoot -= CreateLaser;
                shipInput.Disable();
            }
        }
    }
}