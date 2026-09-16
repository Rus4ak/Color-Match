public enum Difficulty
{
    Easy,
    Medium,
    Hard
}

public class GameDifficulty
{
    public static Difficulty Difficulty { get; set; } = Difficulty.Easy;
}
