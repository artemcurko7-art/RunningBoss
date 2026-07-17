using Game.Scripts.Menu.Game.Paused;
using Game.Scripts.Menu.Game.Paused.Type;
using Game.Scripts.Menu.Game.Resumed.Subscriber;

namespace Game.Scripts.Menu.Game.Resumed
{
    public class GameplayGameResumed : GameResumedSubscriber
    {
        private readonly IGame _game;

        public GameplayGameResumed(IGame game)
            : base(game)
        {
        }

        protected override void OnGameResumed()
        {
            GamePaused.Set(GamePausedType.Play);
        }
    }
}