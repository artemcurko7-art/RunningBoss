using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private HealthPresenter _healthPresenter;
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private Animator _animator;
    
    public override void InstallBindings()
    {
        Container.
            Bind<PlayerStats>().
            FromInstance(_playerStats).
            AsSingle();
        
        Container.
            Bind<IHealthPresenter>().
            FromInstance(_healthPresenter).
            AsSingle();
        
        Container.
            Bind<Animator>().
            FromInstance(_animator).
            AsSingle();
    }
}