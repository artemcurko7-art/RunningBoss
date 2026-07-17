using Game.Scripts.Menu.Game.Paused.Type;

namespace Game.Scripts.Menu.Game.Paused
{
    public static class GamePaused
    {
        public static GamePausedType Type { get; private set; }

        public static void Set(GamePausedType type)
        {
            Type = type;
        }
    }
}