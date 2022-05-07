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
            if (collision.gameObject.layer == LayerMask.NameToLayer("Ship"))
            {
                Destroy(collision.gameObject);
                ShipDestoyed?.Invoke();
            }
            Destroyed?.Invoke(transform.position, this);
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            Destroyed = null;
            ShipDestoyed = null;
        }
    }
}