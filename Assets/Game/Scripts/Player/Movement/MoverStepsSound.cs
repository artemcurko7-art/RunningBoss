using Game.Scripts.Sound.Effects;
using Game.Scripts.Sound.Type;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player.Movement
{
    public class MoverStepsSound : MonoBehaviour
    {
        private SoundService _created;

        [Inject]
        public void Construct(SoundService created)
        {
            _created = created;
        }

        public void PlayFootstep()
        {
            _created.Sounds[SoundType.Steps].Play();
        }
    }
}