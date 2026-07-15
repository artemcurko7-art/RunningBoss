using UnityEngine;
using UnityEngine.UI;
using YG;

public class ProgressView : MonoBehaviour
{
    [SerializeField] private ProgressBar _bar;
    [SerializeField] private ProgressText _progressText;
    [SerializeField] private ProgressLevelIcon _levelIcon;
    [SerializeField] private ProgressReceivingRewardButton _rewardButton;
    [SerializeField] private ProgressRewardText _rewardText;
    [SerializeField] private ProgressRewardAllCompleted _allCompleted;
    [SerializeField] private Image _icon;
    [SerializeField] private PrefabLocalization _nameLocalization;
    [SerializeField] private PrefabLocalization _descriptionLocalization;
    
    public void Initialize(Progress progress)
    {
        _icon.sprite = progress.Config.Icon;
        _nameLocalization.Initialize(YG2.envir.language, progress.Config.NameRussian, progress.Config.NameEnglish, progress.Config.NameTurkish);
        _descriptionLocalization.Initialize(YG2.envir.language, progress.Config.DescriptionRussian, progress.Config.DescriptionEnglish, progress.Config.DescriptionTurkish);
        _bar.Initialize(progress.Experience);
        _progressText.Initialize(progress.Experience);
        _levelIcon.Initialize(progress.Level);
        _rewardButton.Initialize(progress.Config.Type, progress.Reward);
        _rewardText.Initialize(progress.Reward);
        _allCompleted.Initialize(progress.Config.Type, progress.Level, progress.Reward);
        
        progress.Experience.Update();
        progress.Level.Update();
        progress.Reward.Update();
        
        transform.localScale = Vector3.one;
    }
}