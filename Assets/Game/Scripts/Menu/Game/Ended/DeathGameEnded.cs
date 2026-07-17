using Game.Scripts.Player.Death;
using Game.Scripts.Service;

namespace Game.Scripts.Menu.Game.Ended
{
    public class DeathGameEnded : ISubscriber
    {
        private readonly Game _game;
        private readonly IDeath _death;

        public DeathGameEnded(Game game, IDeath death)
        {
            _game = game;
            _death = death;
        }

        public void Subscribe()
        {
            _death.Died += _game.OnEnded;
        }

        public void Unsubscribe()
        {
            _death.Died -= _game.OnEnded;
        }
    }
}