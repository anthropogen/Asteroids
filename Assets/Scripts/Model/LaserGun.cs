using System;

namespace Asteroids.Model
{
    public class LaserGun : Gun
    {
        private readonly int maxBullets;
        private readonly Timer timer;
        private int bullets;

        public LaserGun(int maxBullets, float timeRestoring)
        {
            this.maxBullets = maxBullets;
            bullets = maxBullets;
            timer = new Timer(new UnityEngine.Vector2(timeRestoring, timeRestoring));
            timer.TimePassed += RestoreBullet;
            AfterShootAction += DicreaceBullets;
        }


        public override bool CanShoot()
        {
            return bullets > 0;
        }

        public void TickTimer(float timeDeltaTime)
        {
            timer.Tick(timeDeltaTime);
        }
        private void RestoreBullet()
        {
            bullets += 1;
            bullets = Math.Clamp(bullets, 0, maxBullets);
        }
        private void DicreaceBullets()
        {
            bullets -= 1;
            bullets = Math.Clamp(bullets, 0, maxBullets);
        }
    }
}
