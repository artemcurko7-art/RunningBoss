using Game.Scripts.Sound.Type;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Sound.Music
{
    public class MenuBackgroundMusic : MonoBehaviour
    {
        [Inject]
        public void Construct(BackgroundMusicService service)
        {
            service.BackgroundMusics[BackgroundMusicType.Menu].Play();
        }
    }
}