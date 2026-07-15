using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonGameResumed : MonoBehaviour
{
    [SerializeField] private TabView _view;
    [SerializeField] private Button _button;
    [SerializeField] private GameObject[] _disablings;

    private Game _game;
    private Animator _animator;
    
    [Inject]
    public void Construct(Game game, [InjectOptional] Animator animator)
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
        if (_disablings == null)
            return;
        
        _game.OnResumed();
        _view.gameObject.SetActive(false);
        
        foreach (var obj in _disablings)
            obj.SetActive(true);
        
        _animator.SetBool(PlayerAnimatorData.Params.IsRun, true);
    }
}