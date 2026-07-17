using Game.Scripts.Service;

namespace Game.Scripts.Menu.Game.Paused.Subscriber
{
    public abstract class GamePausedSubscriber : ISubscriber
    {
        private readonly IGame _game;

        public GamePausedSubscriber(IGame game)
        {
            _game = game;
        }

        public void Subscribe()
        {
            _game.Paused += OnGamePaused;
        }

        public void Unsubscribe()
        {
            _game.Paused -= OnGamePaused;
        }

        protected abstract void OnGamePaused();
    }
}