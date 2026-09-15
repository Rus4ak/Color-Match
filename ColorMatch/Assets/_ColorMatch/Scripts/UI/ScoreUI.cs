using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private void Start()
    {
        ScoreData.Instance.ScoreChanged += UpdateScoreText;

        UpdateScoreText();
    }

    private void OnDisable()
    {
        ScoreData.Instance.ScoreChanged -= UpdateScoreText;
    }

    private void UpdateScoreText()
    {
        _scoreText.text = ScoreData.Instance.Score.ToString();
    }
}
