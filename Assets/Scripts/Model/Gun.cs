using System;

namespace Asteroids.Model
{
    public class Gun
    {
        public event Action Shoot;
        public event Action AfterShootAction;
        public virtual bool CanShoot()
            => true;

        public void TryShot()
        {
            if (CanShoot())
                Shoot?.Invoke();
            AfterShootAction?.Invoke();
        }
    }
}
