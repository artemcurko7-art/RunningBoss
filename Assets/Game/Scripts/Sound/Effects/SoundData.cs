using System.Collections.Generic;
using System;
using Game.Scripts.Configs;
using Game.Scripts.Sound.Type;
using UnityEngine;

namespace Game.Scripts.Sound.Effects
{
    public class SoundData
    {
        private readonly Dictionary<SoundType, AudioSource> _sounds = new();

        public SoundData()
        {
            var configs = Resources.LoadAll<SoundConfig>("Config/Sound");

            foreach (var config in configs)
            {
                if (config.Type == SoundType.None)
                    throw new InvalidOperationException($"Not type: {config.Type}");

                if (_sounds.ContainsKey(config.Type))
                    throw new InvalidOperationException($"There is already such a key: {config.Type}");

                _sounds.Add(config.Type, config.AudioSource);
            }
        }

        public IReadOnlyDictionary<SoundType, AudioSource> Sounds => _sounds;
    }
}