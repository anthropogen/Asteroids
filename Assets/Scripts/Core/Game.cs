using System;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

namespace Asteroids.Core
{
    [RequireComponent(typeof(GameFactory))]
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameFactory gameFactory;
        private Timer timer;
        private Camera cam;
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
        }


        private void Start()
        {
            gameFactory.CreateShip();
        }


        private void Update()
        {
            timer.Tick(Time.deltaTime);
        }
        private void CreateEnemy()
        {
            var position = GetRandomPos();
            gameFactory.CreateBigAsteroid(position, GetDirection(position));
        }
        private void OnShipDestroyed()
        {
            SceneManager.LoadScene(0);
        }

        private Vector2 GetDirection(Vector2 position)
        {
            var viewPortPos = cam.ViewportToWorldPoint(new Vector3(Random.value, Random.value, 0));
            return (new Vector2(viewPortPos.x, viewPortPos.y) - position).normalized;
        }
        private Vector2 GetRandomPos()
        {
            var viewPortPos = Random.insideUnitCircle + new Vector2(0.7f, 0.7f);
            var pos = cam.ViewportToWorldPoint(viewPortPos);
            pos.z = 0;
            return pos;
        }
        private void OnDisable()
        {
            timer.TimePassed -= CreateEnemy;
            gameFactory.ShipDestroyed -= OnShipDestroyed;
        }
    }
}