using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private GameTimer _gameTimer;

    private void OnEnable()
    {
        _gameTimer.TimeChanged += UpdateTimerText;

        UpdateTimerText();
    }

    private void OnDisable()
    {
        _gameTimer.TimeChanged -= UpdateTimerText;
    }

    private void UpdateTimerText()
    {
        _timerText.text = _gameTimer.RemainingTime.ToString();
    }
}
