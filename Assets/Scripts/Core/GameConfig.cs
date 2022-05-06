using UnityEngine;

namespace Asteroids.Core
{
    [CreateAssetMenu(fileName = "NewGameConfig", menuName = "GameConfig", order = 51)]
    public class GameConfig : ScriptableObject
    {
        [field: SerializeField, Range(0.01f, 0.1f)] public float ShipSpeed { get; private set; } = 0.05f;
        [field: SerializeField, Range(0.1f, 10f)] public float UfoSpeed { get; private set; } = 2f;
        [field: SerializeField, Range(0.1f, 10f)] public float AsteroidSpeed { get; private set; } = 3f;
        [field: SerializeField, Range(0.1f, 30f)] public float BulletSpeed { get; private set; } = 3f;
        [field: SerializeField, Range(0.1f, 10f)] public float DelayBeforeDestroyBullet { get; private set; } = 3f;
        [field: SerializeField, Range(0.1f, 10f)] public float DelayBeforeDestroyLaser { get; private set; } = 1f;
        [field: SerializeField, Range(0, 1)] public float UfoCreateChance { get; private set; } = 0.3f;
        [field: SerializeField, Range(0, 10)] public float TimeLaserRestoring { get; private set; } = 5f;
        [field: SerializeField, Range(0, 10)] public int MaxBullets { get; private set; } = 3;
    }
}