using Game.Scripts.MV.Progress;
using Game.Scripts.MV.Progress.Type;
using System.Collections.Generic;

namespace YG
{
    public partial class SavesYG 
    {
        public Dictionary<ProgressType, ProgressStorageData> Progresses = new ();

        public void AddProgress(Progress progress)
        {
            if (Progresses.ContainsKey(progress.Config.Type))
                return;
            
            Progresses.Add(progress.Config.Type, Create(progress));
        }

        public void ProgressStorage(Progress progress)
        {
            Progresses[progress.Config.Type] = Create(progress);
        }

        private ProgressStorageData Create(Progress progress)
        {
            ProgressStorageData data = new ()
            {
                ExperienceValue = progress.Experience.Value,
                ExperienceMaxValue = progress.Experience.MaxValue,
                Level = progress.Level.Value,
                Rewards = progress.Reward.Rewards,
            };

            return data;
        }
    } 
}