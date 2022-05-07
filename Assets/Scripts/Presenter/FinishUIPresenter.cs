using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Asteroids.Presenter
{
    public class FinishUIPresenter : MonoBehaviour
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private TMP_Text scoreText;

        private void OnEnable()
            => restartButton.onClick.AddListener(RestartGame);

        private void OnDisable()
            => restartButton.onClick.RemoveAllListeners();

        public void Init(int score)
            => scoreText.text = $"Score: {score}";

        public void RestartGame()
            => SceneManager.LoadScene(0);
    }
}