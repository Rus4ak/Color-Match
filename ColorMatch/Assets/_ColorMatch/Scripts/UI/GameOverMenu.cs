using TMPro;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private void Start()
    {
        _scoreText.text = $"Score: {ScoreData.Instance.Score.ToString()}";
    }
}
