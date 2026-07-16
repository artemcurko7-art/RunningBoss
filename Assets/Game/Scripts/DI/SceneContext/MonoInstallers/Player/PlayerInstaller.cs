using UnityEngine;
using Zenject;
    
public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private CoinStats _stats;
    
    private Animal _animal;
    
    [Inject]
    public void Construct(Animal animal)
    {
        _animal = animal;
    }
    
    public override void InstallBindings()
    {
        BindHealth();
        BindCollectorCoin();
    }

    private void BindHealth()
    {
        Container
            .BindInterfacesAndSelfTo<Health>()
            .FromInstance(new Health(AnimalType.None, null, _animal.Stats[StatType.Health].Value))
            .AsSingle();
    }

    private void BindCollectorCoin()
    {
        Container
            .BindInterfacesAndSelfTo<CoinData>()
            .AsSingle();
        
        Container
            .Bind<CoinStats>()
            .FromInstance(_stats)
            .AsSingle();
    }
}