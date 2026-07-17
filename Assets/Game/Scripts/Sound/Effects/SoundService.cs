using System.Collections.Generic;
using Game.Scripts.Sound.Type;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Sound.Effects
{
    public class SoundService
    {
        private readonly Dictionary<SoundType, AudioSource> _sounds = new();

        public SoundService(SoundData data, DiContainer container)
        {
            foreach (var sound in data.Sounds)
            {
                AudioSource audioSource =
                    container.InstantiatePrefabForComponent<AudioSource>(sound.Value, Vector3.zero, Quaternion.identity,
                        null);
                _sounds.Add(sound.Key, audioSource);
            }
        }

        public IReadOnlyDictionary<SoundType, AudioSource> Sounds => _sounds;
    }
}