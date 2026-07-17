using System;
using UnityEngine;

namespace Game.Scripts.Configs
{
    [Serializable]
    public class ImprovementConfig 
    {
        [field: SerializeField] public int[] Values { get; private set; }
    }
}