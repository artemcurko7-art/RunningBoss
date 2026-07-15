using System;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicData  
{
    private readonly Dictionary<BackgroundMusicType, AudioSource> _backgroundMusics = new();
    
    public BackgroundMusicData()
    {
        var configs = Resources.LoadAll<BackgroundMusicConfig>("Config/BackgroundMusic");
        
        foreach (var config in configs)
        {
            if (config.Type == BackgroundMusicType.None)
                throw new InvalidOperationException($"Not type: {config.Type}");
            
            if (_backgroundMusics.ContainsKey(config.Type))
                throw new InvalidOperationException($"There is already such a key: {config.Type}");
            
            _backgroundMusics.Add(config.Type, config.AudioSource);
        }
    }

    public IReadOnlyDictionary<BackgroundMusicType, AudioSource> BackgroundMusics => _backgroundMusics;
}
