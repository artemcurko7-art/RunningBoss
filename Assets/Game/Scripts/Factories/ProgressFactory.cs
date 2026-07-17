using Game.Scripts.Configs;
using Game.Scripts.MV.Progress;
using Game.Scripts.MV.Progress.Experience;
using Game.Scripts.MV.Progress.Level;
using Game.Scripts.MV.Progress.Reward;

namespace Game.Scripts.Factories
{
    public class ProgressFactory
    {
        public Progress Create(ProgressConfig Config)
        {
            var experience = new ProgressExperience(Config.MaxValue, Config.MultiplierMaxValue);
            var level = new ProgressLevel();
            var reward = new ProgressReward(Config.Reward, Config.MultiplierReward);

            Progress progress = new Progress(Config, experience, level, reward);

            return progress;
        }
    }
}