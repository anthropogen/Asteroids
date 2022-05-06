using Asteroids.Model;
using System;
using UnityEngine;
namespace Asteroids.Presenter
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyPresenter : Presenter
    {
        public event Action<Vector2, EnemyPresenter> Destroyed;
        public event Action ShipDestoyed;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (Model is Asteroid)
            {
                var asteroid = Model as Asteroid;
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