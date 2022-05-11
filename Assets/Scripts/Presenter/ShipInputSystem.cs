using Asteroids.Model;
using UnityEngine;

public class ShipInputSystem : MonoBehaviour
{
    [SerializeField] private Ship ship;
    private ShipInput shipInput;

    public void Init(Ship ship, ShipInput input)
    {
        this.ship = ship;
        this.shipInput = input;
    }

    private void Update()
    {
        if (ship == null) return;
        ReadInput();
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
}
