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