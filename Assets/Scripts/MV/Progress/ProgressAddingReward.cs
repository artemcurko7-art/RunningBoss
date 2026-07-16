using System;
using System.Collections.Generic;
using UnityEngine;

public class ProgressAddingReward
{
    private readonly Dictionary<ProgressType, bool> _receivedData = new ();
    
    public ProgressAddingReward()
    {
        var configs = Resources.LoadAll<ProgressConfig>("Config/Progress");

        foreach (var config in configs)
            _receivedData.Add(config.Type, false);
    }
    
    public IReadOnlyDictionary<ProgressType, bool> ReceivedData => _receivedData;
    
    public void Receive(ProgressType type)
    {
        if (_receivedData.ContainsKey(type) == false)
            throw new InvalidOperationException($"Not {type}");
        
        _receivedData[type] = true;
    }
}