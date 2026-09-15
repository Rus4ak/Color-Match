using TMPro;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _bestScoreText;

    private SceneLoader _sceneLoader;

    private void Awake()
    {
        _sceneLoader = GetComponent<SceneLoader>();
    }

    private void Start()
    {
        _bestScoreText.text = $"Best Score: {PlayerPrefs.GetInt("BestScore", 0)}";
    }

    public void SelectDifficulty(int difficulty)
    {
        GameDifficulty.Difficulty = (Difficulty)difficulty;
        _sceneLoader.Load("Game");
    }
}
