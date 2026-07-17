using UnityEngine;

namespace Game.Scripts.MV.Quest.View
{
    public class QuestShowingRewardButton : MonoBehaviour
    {
        [SerializeField] private QuestReceivingRewardButton _rewardButton;
        [SerializeField] private GameObject _completed;
        [SerializeField] private GameObject _ads;

        private IQuest _quest;

        public void Initialize(IQuest quest)
        {
            _quest = quest;

            _quest.Changed += OnValueChanged;

            if (_quest.Reward == 0)
            {
                _completed.SetActive(true);
                _ads.SetActive(false);
            }
        }

        private void OnDestroy()
        {
            _quest.Changed -= OnValueChanged;
        }

        private void OnValueChanged(int value)
        {
            if (_rewardButton == null)
                return;

            if (value == _quest.MaxValue && _quest.Reward > 0)
            {
                _rewardButton.gameObject.SetActive(true);
                _ads.SetActive(false);
            }

            if (_quest.Reward == 0)
            {
                _completed.SetActive(true);
                _ads.SetActive(false);
            }
        }
    }
}