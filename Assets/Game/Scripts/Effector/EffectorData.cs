using Game.Scripts.Configs;
using Game.Scripts.Effector.Type;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Effector
{
    public class EffectorData
    {
        private readonly Dictionary<EffectorType, Effector> _effectors = new();
        private readonly EffectorConfig[] _configs;

        public EffectorData()
        {
            _configs = Resources.LoadAll<EffectorConfig>("Config/Effector");

            Fill();
        }

        public IReadOnlyDictionary<EffectorType, Effector> Effectors => _effectors;

        private void Fill()
        {
            foreach (var config in _configs)
            {
                if (config.Type == EffectorType.None)
                    throw new InvalidOperationException($"Not effector: {config.Effector.name}, type: {config.Type}");

                if (_effectors.ContainsKey(config.Type))
                    throw new InvalidOperationException($"There is already such a key: {config.Type}");

                _effectors.Add(config.Type, config.Effector);
            }
        }
    }
}