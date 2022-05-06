using Asteroids.Model;
using Asteroids.Presenter;
using UnityEngine;

namespace Asteroids.Core
{
    public class GameFactory : MonoBehaviour
    {
        [SerializeField] private ShipPresenter shipTemplate;
        private ShipPresenter shipPresenter;
        public void CreateShip()
        {
            if (shipPresenter != null)
                return;
            shipPresenter = Instantiate<ShipPresenter>(shipTemplate);
            Ship ship = new Ship(Vector3.zero, Quaternion.identity, 0.05f);
            shipPresenter.Init(ship);
            shipPresenter.InitShip(new ShipInput());
        }
    }
}