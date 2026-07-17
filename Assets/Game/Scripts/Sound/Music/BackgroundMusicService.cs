using System.Collections.Generic;
using Game.Scripts.Sound.Type;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Sound.Music
{
    public class BackgroundMusicService
    {
        private readonly Dictionary<BackgroundMusicType, AudioSource> _backgroundMusics = new();

        public BackgroundMusicService(BackgroundMusicData data, DiContainer container)
        {
            foreach (var sound in data.BackgroundMusics)
            {
                AudioSource audioSource =
                    container.InstantiatePrefabForComponent<AudioSource>(sound.Value, Vector3.zero, Quaternion.identity,
                        null);
                _backgroundMusics.Add(sound.Key, audioSource);
            }
        }

        public IReadOnlyDictionary<BackgroundMusicType, AudioSource> BackgroundMusics => _backgroundMusics;
    }
}