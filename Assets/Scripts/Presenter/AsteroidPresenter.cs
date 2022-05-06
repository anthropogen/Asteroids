using Asteroids.Model;
using System;
using UnityEngine;
namespace Asteroids.Presenter
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class AsteroidPresenter : Presenter
    {
        public event Action<Vector2, AsteroidPresenter> Destroyed;
        public event Action ShipDestoyed;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var asteroid = Model as Asteroid;
            if (asteroid.IsDestroyable)
            {
                Destroyed?.Invoke(transform.position, this);
            }
            if (collision.gameObject.layer == LayerMask.NameToLayer("Ship"))
            {
                Destroy(collision.gameObject);
                ShipDestoyed?.Invoke();
            }
            Destroy(gameObject);
        }
        private void OnDestroy()
        {
            Destroyed = null;
            ShipDestoyed = null;
        }
    }
}