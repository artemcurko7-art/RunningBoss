using System;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class ProgressData : IProgressData
{
    private readonly Dictionary<ProgressType, Progress> _progresses = new ();
    private readonly ProgressConfig[] _configs;
    private readonly ProgressFactory _factory;

    public ProgressData(ProgressFactory factory)
    {
        _factory = factory;
        _configs = Resources.LoadAll<ProgressConfig>("Config/Progress");

        Fill();
    }

    public IReadOnlyDictionary<ProgressType, Progress> Progresses => _progresses;

    private void Fill()
    {
        foreach (var type in Enum.GetValues(typeof(ProgressType)))
        {
            foreach (var config in _configs)
            {
                if (config.Type == (ProgressType)type)
                {
                    var progress = _factory.Create(config);
                    YG2.saves.AddProgress(progress);
                    Add(config.Type, progress);
                }
            }
        }
    }
    
    private void Add(ProgressType type, Progress progress)
    {
        if (type == ProgressType.None)
            throw new InvalidOperationException($"Not key: {type}");
        
        if (_progresses.ContainsKey(type))
            throw new InvalidOperationException($"There is already such a key: {type}");

        foreach (var data in YG2.saves.Progresses)
        {
            if (data.Key == progress.Config.Type)
            {
                progress.Experience.SetValue(data.Value.ExperienceValue);
                progress.Experience.SetMaxValue(data.Value.ExperienceMaxValue);
                progress.Level.SetValue(data.Value.Level);
                progress.Reward.SetValue(data.Value.Rewards);
            }
        }
        
        _progresses.Add(type, progress);
    }
}