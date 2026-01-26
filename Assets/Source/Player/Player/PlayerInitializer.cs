using UnityEngine;

public class PlayerInitializer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerAnimation _animation;
    [SerializeField] private HealthPresenter _healthPresenter;

    private PlayerAnimationAttacker _attacker;

    private void Awake()
    {
        _player.Initialize(_healthPresenter, _animation.Animator);
        _attacker = new PlayerAnimationAttacker(_player, _animation.Animator);
    }

    private void OnEnable()
    {
        _attacker.OnEnable();
    }

    private void OnDisable()
    {
        _attacker.OnDisable();
    }
}