using UnityEngine;

namespace Asteroids.Core
{
    [RequireComponent(typeof(GameFactory))]
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameFactory gameFactory;
        private void Awake()
        {
            gameFactory = gameFactory == null ? GetComponent<GameFactory>() : gameFactory;
        }

        private void Start()
        {
            gameFactory.CreateShip();
        }
    }
}