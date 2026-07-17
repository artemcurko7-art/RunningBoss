using Game.Scripts.Configs;
using Game.Scripts.MV.Progress.Experience;
using Game.Scripts.MV.Progress.Level;
using Game.Scripts.MV.Progress.Reward;

namespace Game.Scripts.MV.Progress
{
    public class Progress
    {
        public Progress(ProgressConfig config, ProgressExperience experience, ProgressLevel level, ProgressReward reward)
        {
            Config = config;
            Experience = experience;
            Reward = reward;
            Level = level;
        }

        public ProgressConfig Config { get; }
        public ProgressExperience Experience { get; }
        public ProgressLevel Level { get; }
        public ProgressReward Reward { get; }

        public void SetValue(int value)
        {
            if (Level.Value == Level.MaxValue)
                return;

            Experience.Add(value);

            while (Experience.Value >= Experience.MaxValue)
            {
                Experience.SetValue(Experience.Value - Experience.MaxValue);

                Level.Up();
                Reward.Add(Reward.Value);

                if (Level.Value < Level.MaxValue)
                {
                    Experience.UpMultiplerValue();
                    Reward.UpMultiplerValue();
                }
            }
        }
    }
}