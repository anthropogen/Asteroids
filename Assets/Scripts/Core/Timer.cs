using System;
using UnityEngine;
using Random = UnityEngine.Random;
namespace Asteroids.Core
{
    public class Timer
    {
        private Vector2 timeDelayRange;
        private float timeDelay;
        private float currentTime;
        public event Action TimePassed;
        public Timer(Vector2 timeDelayRange)
        {
            this.timeDelayRange = timeDelayRange;
            timeDelay = RandomizeTime();
        }

        public void Tick(float timeDeltaTime)
        {
            if (currentTime > timeDelay)
            {
                currentTime = 0;
                timeDelay = RandomizeTime();
                TimePassed?.Invoke();
            }
            currentTime += timeDeltaTime;
        }
        private float RandomizeTime()
            => Random.Range(timeDelayRange.x, timeDelayRange.y);
    }
}