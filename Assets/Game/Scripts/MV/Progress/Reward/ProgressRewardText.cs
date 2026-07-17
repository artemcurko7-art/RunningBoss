using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.Scripts.MV.Progress.Reward
{
    public class ProgressRewardText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _rewardText;

        private IProgressReward _reward;

        public void Initialize(IProgressReward reward)
        {
            _reward = reward;

            _reward.Rewarded += OnRewarded;
        }

        private void OnDestroy()
        {
            _reward.Rewarded -= OnRewarded;
        }

        private void OnRewarded(List<int> values)
        {
            int reward = 0;

            foreach (var value in values)
                reward += value;

            _rewardText.text = reward.ToString();

            if (reward == 0)
                _rewardText.text = _reward.Value.ToString();
        }
    }
}