public static class GamePaused 
{
    public static GamePausedType Type { get; private set; }

    public static void Set(GamePausedType type)
    {
        Type = type;
    }
}