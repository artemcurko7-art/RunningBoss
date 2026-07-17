using UnityEngine;
using Zenject;

namespace Game.Scripts.Menu.Game.Paused
{
    public class StartedGamePaused : MonoBehaviour
    {
        [Inject]
        public void Construct(Game game)
        {
            game.OnPaused();
        }
    }
}