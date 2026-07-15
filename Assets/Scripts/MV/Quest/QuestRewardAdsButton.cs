using System;
using UnityEngine;
using UnityEngine.UI;
using YG;
using Zenject;

public class QuestRewardAdsButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _completed;
    [SerializeField] private GameObject _allCompleted;
    [SerializeField] private GameObject _ads;

    private Wallet _wallet;
    private Quest _quest;

    [Inject]
    public void Construct(Wallet wallet)
    {
        _wallet = wallet;
    }
    
    public void Initialize(Quest quest)
    {
        _quest = quest;
        
        _button.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        if (_button == null)
            return;
        
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        YG2.RewardedAdvShow("", () =>
        {
            _wallet.AddCoin(_quest.Reward);
            _quest.SetValue(int.MaxValue);
            _quest.SetReward(0);
            _completed.SetActive(false);
            _ads.SetActive(false);
            _allCompleted.SetActive(true);
            YG2.saves.QuestStorage(_quest);
        });
    }
}
