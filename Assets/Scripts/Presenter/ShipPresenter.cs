using Asteroids.Core;
using Asteroids.Model;
using System;
using UnityEngine;

namespace Asteroids.Presenter
{
    public class ShipPresenter : Presenter
    {
        [SerializeField] private Transform shootPos;
        private Ship ship;
        private ShipInput shipInput;
        private Camera cam;
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
            UpdateAction += OnUpdate;
            cam = Camera.main;
            this.gameFactory = gameFactory;
        }

        private void OnUpdate()
        {
            if (shipInput == null)
                return;
            ReadInput();
            KeepShipPositionOnScreen();
        }

        private void ReadInput()
        {
            if (shipInput.Ship.ForwardMovement.phase == UnityEngine.InputSystem.InputActionPhase.Performed)
            {
                ship.OnForwardMovement();
            }
            float rotation = shipInput.Ship.Rotation.ReadValue<float>();
            if (rotation != 0)
            {
                ship.OnRotate(rotation);
            }
        }

        private void CreateBullet()
            => gameFactory.GetBulletAt(shootPos.position, ship.Rotation);

        private void CreateLaser()
            => gameFactory.GetLaserAt(shootPos.position, ship.Rotation, transform);

        private void KeepShipPositionOnScreen()
        {
            Vector2 viewPortPos = cam.WorldToViewportPoint(ship.Position);
            viewPortPos.x = Mathf.Repeat(viewPortPos.x, 1);
            viewPortPos.y = Mathf.Repeat(viewPortPos.y, 1);
            ship.MoveTo(cam.ViewportToWorldPoint(viewPortPos));
        }

        private void OnDestroy()
        {
            UpdateAction -= OnUpdate;
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