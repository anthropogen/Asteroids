using Asteroids.Model;
using UnityEngine;

namespace Asteroids.Presenter
{
    public class ProjectilePresenter : Presenter
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var bullet = Model as Projectile;
            bullet.Destroy();
            Destroy(collision.gameObject);
        }
    }
}