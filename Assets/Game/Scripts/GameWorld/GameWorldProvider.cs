using Game.Scripts.Configs;

namespace Game.Scripts.GameWorld
{
    public class GameWorldProvider
    {
        private GameWorldProvider(GameWorldData data)
        {
            Config = data.GetConfig();
        }

        public GameWorldConfig Config { get; }
    }
}