using System.Collections.Generic;
using UnityEngine;

public class ProgressRewardAllCompleted : MonoBehaviour
{
    [SerializeField] private GameObject _allCompleted;

    private ProgressType _type;
    private ProgressLevel _level;
    private IProgressReward _reward;
    
    public void Initialize(ProgressType type, ProgressLevel level, IProgressReward reward)
    {
        _type = type;
        _level = level;
        _reward = reward;

        _reward.Rewarded += OnRewarded;
    }

    private void OnDestroy()
    {
        _reward.Rewarded -= OnRewarded;
    }

    private void OnRewarded(IReadOnlyList<int> rewards)
    {
        if (_allCompleted == null)
            return;
        
        if(_level.Value == _level.MaxValue && rewards.Count == 0)
            _allCompleted.SetActive(true);
    }
}