using UnityEngine;
using UnityEngine.UI;
using YG;
using Zenject;

public class ProgressReceivingRewardButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    
    private ProgressType _type;
    private Wallet _wallet;
    private IProgressReward _reward;
    private IProgressData _data;
    private SoundService _soundService;
    
    [Inject]
    public void Construct(Wallet wallet, IProgressData data, SoundService soundService)
    {
        _wallet = wallet;
        _data = data;
        _soundService = soundService;
    }
    
    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    public void Initialize(ProgressType type, IProgressReward reward)
    {
        _type = type;
        _reward = reward;

        if (reward.Rewards.Count > 0)
            gameObject.SetActive(true);
    }

    private void OnClick()
    {
        for (int i = _reward.Rewards.Count; i > 0; i--)
            _wallet.AddCoin(_reward.GetValueRemoved());  
        
        gameObject.SetActive(false);
        YG2.saves.ProgressStorage(_data.Progresses[_type]);
        _soundService.Sounds[SoundType.StatLevelUp].Play();
    } 
}