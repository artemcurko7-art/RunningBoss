using Game.Scripts.Localization;
using Game.Scripts.MV.Quest.View;
using TMPro;
using UnityEngine;
using YG;

namespace Game.Scripts.MV.Quest
{
    public class QuestView : MonoBehaviour
    {
        [SerializeField] private QuestBar _bar;
        [SerializeField] private QuestText _text;
        [SerializeField] private QuestShowingRewardButton _showingRewardButton;
        [SerializeField] private QuestReceivingRewardButton _rewardButton;
        [SerializeField] private QuestRewardAdsButton _adsButton;
        [SerializeField] private PrefabLocalization _nameLocalization;
        [SerializeField] private PrefabLocalization _descriptionLocalization;
        [SerializeField] private TMP_Text _reward;

        public void Initialize(Quest quest)
        {
            _nameLocalization.Initialize(YG2.envir.language, quest.Config.NameRussian, quest.Config.NameEnglish,
                quest.Config.NameTurkish);
            _descriptionLocalization.Initialize(YG2.envir.language, quest.Config.DescriptionRussian,
                quest.Config.DescriptionEnglish, quest.Config.DescriptionTurkish);
            _reward.text = quest.Config.Reward.ToString();

            _bar.Initialize(quest);
            _text.Initialize(quest);
            _showingRewardButton.Initialize(quest);
            _rewardButton.Initialize(quest);
            _adsButton.Initialize(quest);

            quest.Update();

            transform.localScale = Vector3.one;
        }
    }
}