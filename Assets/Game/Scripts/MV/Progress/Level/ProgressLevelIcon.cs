using UnityEngine;
using UnityEngine.UI;

public class ProgressLevelIcon : MonoBehaviour
{
    [SerializeField] private Image[] _fillings;
    [SerializeField] private Sprite _levelIcon;

    private IProgressLevel _level;
    
    public void Initialize(IProgressLevel level)
    {
        _level = level;
        
        _level.Upped += OnLevelUpped;

        for (int i = 0; i < _level.Value; i++)
            _fillings[i].sprite = _levelIcon;
    }

    private void OnDestroy()
    {
        _level.Upped -= OnLevelUpped;
    }

    private void OnLevelUpped(int currentLevel)
    {
        if (_level.Value == 0)
            return;

        if (_fillings[currentLevel - 1] == null)
            return; 

        _fillings[currentLevel - 1].sprite = _levelIcon;
    }
}