using UnityEngine;
using Zenject;

public class StartedGamePaused : MonoBehaviour
{
    [Inject]
    public void Construct(Game game)
    {
        game.OnPaused();
    }
}