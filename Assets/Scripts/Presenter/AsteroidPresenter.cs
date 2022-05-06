using Asteroids.Model;
using System;
using UnityEngine;
namespace Asteroids.Presenter
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class AsteroidPresenter : Presenter
    {
        public event Action<Vector2> Destroyed;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var asteroid = Model as Asteroid;
            if (asteroid.IsDestroyable)
            {
                Destroyed?.Invoke(transform.position);
            }
            Destroy(gameObject);
        }
    }
}