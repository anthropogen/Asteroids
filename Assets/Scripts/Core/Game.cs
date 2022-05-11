using Asteroids.Model;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids.Core
{
    [RequireComponent(typeof(GameFactory))]
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameFactory gameFactory;
        [SerializeField] public GameConfig gameConfig;
        [SerializeField] private ShipInputSystem shipInputSystem;
        private Timer timer;
        private Camera cam;
        private int enemyDestroyed;
        private bool isFinish = false;
        private void Awake()
        {
            gameFactory = gameFactory == null ? GetComponent<GameFactory>() : gameFactory;
            cam = Camera.main;
            timer = new Timer(new Vector2(0.5f, 1.5f));
        }

        private void OnEnable()
        {
            timer.TimePassed += CreateEnemy;
            gameFactory.ShipDestroyed += OnShipDestroyed;
            gameFactory.EnemyDestroyed += OnEnemyDestoyed;
        }


        private void Start()
        {
            ShipInput input = new ShipInput();
            shipInputSystem.Init(gameFactory.CreateShip(input), input);
        }

        private void Update()
        {
            if (!isFinish)
                timer.Tick(Time.deltaTime);
        }

        private void CreateEnemy()
        {
            var position = GetRandomPos();
            if (Random.value > gameConfig.UfoCreateChance)
                gameFactory.CreateBigAsteroid(position, GetDirection(position));
            else
                gameFactory.CreateUfoAt(position);
        }

        private void OnShipDestroyed()
        {
            isFinish = true;
            gameFactory.CreateFinishUI(enemyDestroyed);
        }

        private Vector2 GetDirection(Vector2 position)
        {
            var viewPortPos = cam.ViewportToWorldPoint(new Vector3(Random.value, Random.value, 0));
            return (new Vector2(viewPortPos.x, viewPortPos.y) - position).normalized;
        }

        private Vector2 GetRandomPos()
        {
            var viewPortPos = Random.insideUnitCircle.normalized + new Vector2(0.5f, 0.5f);
            var pos = cam.ViewportToWorldPoint(viewPortPos);
            pos.z = 0;
            return pos;
        }

        private void OnEnemyDestoyed()
            => enemyDestroyed++;

        private void OnDisable()
        {
            timer.TimePassed -= CreateEnemy;
            gameFactory.ShipDestroyed -= OnShipDestroyed;
            gameFactory.EnemyDestroyed -= OnEnemyDestoyed;
        }
    }
}