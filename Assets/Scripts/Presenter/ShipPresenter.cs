using Asteroids.Model;
using System;
using UnityEngine;

namespace Asteroids.Presenter
{
    public class ShipPresenter : Presenter
    {
        private Ship ship;
        private ShipInput shipInput;
        public void InitShip(ShipInput shipInput)
        {
            if (Model == null)
                throw new NullReferenceException("Ship didn't initialize");
            ship = Model as Ship;
            this.shipInput = shipInput;
            shipInput.Enable();
            UpdateAction += OnUpdate;
        }

        private void OnUpdate()
        {
            if (shipInput == null)
                return;
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
    }
}