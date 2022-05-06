using System;

namespace Asteroids.Model
{
    public class LaserGun : Gun
    {
        public readonly int MaxBullets;
        public readonly Timer Timer;
        public event Action<int, int> BulletsChanged;
        public int Bullets { get; private set; }
        public LaserGun(int maxBullets, float timeRestoring)
        {
            MaxBullets = maxBullets;
            Bullets = maxBullets;
            Timer = new Timer(new UnityEngine.Vector2(timeRestoring, timeRestoring));
            Timer.TimePassed += RestoreBullet;
            AfterShootAction += DicreaceBullets;
        }

        public override bool CanShoot()
        {
            return Bullets > 0;
        }

        public void TickTimer(float timeDeltaTime)
        {
            if (Bullets < MaxBullets)
                Timer.Tick(timeDeltaTime);
        }

        private void RestoreBullet()
        {
            Bullets += 1;
            Bullets = Math.Clamp(Bullets, 0, MaxBullets);
            BulletsChanged?.Invoke(Bullets, MaxBullets);
        }

        private void DicreaceBullets()
        {
            Bullets -= 1;
            Bullets = Math.Clamp(Bullets, 0, MaxBullets);
            BulletsChanged?.Invoke(Bullets, MaxBullets);
        }
    }
}
