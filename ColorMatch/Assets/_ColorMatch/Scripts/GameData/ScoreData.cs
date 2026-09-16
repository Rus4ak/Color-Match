using System;
using UnityEngine;

public class ScoreData : MonoBehaviour 
{
    public static ScoreData Instance { get; private set; }

    private int _score;
    public int Score => _score;

    public event Action ScoreChanged;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void ChangeScore(int value)
    {
        _score += value;
        
        if (_score < 0)
            _score = 0;
        
        ScoreChanged?.Invoke();
    }

    public void ClearScore()
    {
        _score = 0;
    }
}
