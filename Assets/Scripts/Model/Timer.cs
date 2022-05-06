using System;
using UnityEngine;
using Random = UnityEngine.Random;
namespace Asteroids.Model
{
    public class Timer
    {
        private Vector2 timeDelayRange;
        public event Action TimePassed;
        public event Action<float, float> TimeChanged;
        public float CurrentTime { get; private set; }
        public float TimeDelay { get; private set; }
        public Timer(Vector2 timeDelayRange)
        {
            this.timeDelayRange = timeDelayRange;
            TimeDelay = RandomizeTime();
        }

        public void Tick(float timeDeltaTime)
        {
            if (CurrentTime > TimeDelay)
            {
                CurrentTime = 0;
                TimeDelay = RandomizeTime();
                TimePassed?.Invoke();
            }
            else
                CurrentTime += timeDeltaTime;
            TimeChanged?.Invoke(CurrentTime, TimeDelay);
        }
        private float RandomizeTime()
            => Random.Range(timeDelayRange.x, timeDelayRange.y);
    }
}