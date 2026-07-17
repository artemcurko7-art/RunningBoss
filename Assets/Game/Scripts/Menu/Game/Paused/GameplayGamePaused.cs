using Game.Scripts.Menu.Game.Paused.Subscriber;
using Game.Scripts.Menu.Game.Paused.Type;

namespace Game.Scripts.Menu.Game.Paused
{
    public class GameplayGamePaused : GamePausedSubscriber
    {
        private readonly IGame _game;

        public GameplayGamePaused(IGame game) : base(game) { }

        protected override void OnGamePaused()
        {
            GamePaused.Set(GamePausedType.Pause);
        }
    }
}