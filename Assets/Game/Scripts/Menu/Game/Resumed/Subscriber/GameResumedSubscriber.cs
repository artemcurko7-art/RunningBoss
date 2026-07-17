using Game.Scripts.Service;

namespace Game.Scripts.Menu.Game.Resumed.Subscriber
{
    public abstract class GameResumedSubscriber : ISubscriber
    {
        private readonly IGame _game;

        public GameResumedSubscriber(IGame game)
        {
            _game = game;
        }

        public void Subscribe()
        {
            _game.Resumed += OnGameResumed;
        }

        public void Unsubscribe()
        {
            _game.Resumed -= OnGameResumed;
        }

        protected abstract void OnGameResumed();
    }
}