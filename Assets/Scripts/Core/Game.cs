using System;
using UnityEngine;
namespace Asteroids.Core
{
    [RequireComponent(typeof(GameFactory))]
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameFactory gameFactory;
        private Timer timer;
        private void Awake()
        {
            gameFactory = gameFactory == null ? GetComponent<GameFactory>() : gameFactory;
            timer = new Timer(new Vector2(0.5f, 1.5f));
        }
        private void OnEnable()
        {
            timer.TimePassed += CreateEnemy;
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
        }
        private void OnDisable()
        {
            timer.TimePassed -= CreateEnemy;
        }
    }
}