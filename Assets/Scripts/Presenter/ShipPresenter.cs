using Asteroids.Model;
using System;
using UnityEngine;

namespace Asteroids.Presenter
{
    public class ShipPresenter : Presenter
    {
        private Ship ship;
        private ShipInput shipInput;
        private Camera cam;
        public void InitShip(ShipInput shipInput)
        {
            if (Model == null)
                throw new NullReferenceException("Ship didn't initialize");
            ship = Model as Ship;
            this.shipInput = shipInput;
            shipInput.Enable();
            UpdateAction += OnUpdate;
            cam = Camera.main;
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
                shipInput.Disable();
        }
    }
}