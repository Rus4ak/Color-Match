using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _mainCanvas;
    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private GameTimer _gameTimer;

    private void OnEnable()
    {
        _gameTimer.TimerEnded += ActivateGameOverMenu;
    }

    private void OnDisable()
    {
        _gameTimer.TimerEnded -= ActivateGameOverMenu;
    }

    private void ActivateGameOverMenu()
    {
        _mainCanvas.SetActive(false);
        _gameOverCanvas.SetActive(true);

        int score = ScoreData.Instance.Score;
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);

        if (score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
        }

        Time.timeScale = 0;
    }
}
