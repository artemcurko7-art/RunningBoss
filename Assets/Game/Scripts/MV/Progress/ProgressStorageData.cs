using System;
using System.Collections.Generic;

namespace Game.Scripts.MV.Progress
{
    [Serializable]
    public class ProgressStorageData
    {
        public int ExperienceValue;
        public int ExperienceMaxValue;
        public int Level;
        public List<int> Rewards;
    }
}