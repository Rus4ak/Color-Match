using UnityEngine;

public class GameplayInitialize : MonoBehaviour
{
    private void Awake()
    {
        switch (GameDifficulty.Difficulty)
        {
            case Difficulty.Easy:
                EasyDifficulty();
                break;

            case Difficulty.Medium:
                MediumDifficulty();
                break;

            case Difficulty.Hard:
                HardDifficulty();
                break;
        }
    }

    private void EasyDifficulty()
    {
        
    }

    private void MediumDifficulty()
    {

    }

    private void HardDifficulty()
    {

    }
}
