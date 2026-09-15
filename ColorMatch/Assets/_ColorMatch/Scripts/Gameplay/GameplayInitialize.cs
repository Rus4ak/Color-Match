using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class DifficultyConfigs
{
    public Difficulty difficulty;
    public DifficultyValues difficultyValues;
}

public class GameplayInitialize : MonoBehaviour
{
    [SerializeField] private Spawner[] _spawners;
    [SerializeField] private DifficultyConfigs[] _difficultyConfigs;

    private void Awake()
    {
        Time.timeScale = 1;

        SetDifficulty(_difficultyConfigs.First(x => x.difficulty == GameDifficulty.Difficulty).difficultyValues);
    }

    private void Start()
    {
        ScoreData.Instance.ClearScore();
    }

    private void SetDifficulty(DifficultyValues difficultyValues)
    {
        foreach(var spawner in _spawners)
        {
            spawner.Initialize(difficultyValues.shapesSpawnRate, difficultyValues.shapesFallSpeed);
        }
    }
}
