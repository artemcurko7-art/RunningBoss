using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GamePausedButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TabView _tabView;
    [SerializeField] private GameObject[] _disablings;
    
    private Game _game;
    private Animator _animator;
    
    [Inject]
    public void Construct(Game game, Animator animator)
    {
        _game = game;
        _animator = animator;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        _game.OnPaused();
        _tabView.gameObject.SetActive(true);

        foreach (var obj in _disablings)
            obj.SetActive(false);
        
        _animator.SetBool(PlayerAnimatorData.Params.IsRun, false);
        GamePaused.Set(GamePausedType.Pause);
    }
}