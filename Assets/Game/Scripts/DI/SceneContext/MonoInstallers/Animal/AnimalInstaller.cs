using UnityEngine;
using Zenject;

public class AnimalInstaller : MonoInstaller
{
    private const float Size = 0.5f;
    
    [SerializeField] private Transform _spawnPointAnimal;

    private AnimalViewFactory _factory;
    private ItemViewFactory _itemFactory;
    private ItemViewProvider _itemProvider;
    
    [Inject]
    public void Construct(AnimalViewFactory factory, ItemViewFactory itemFactory, ItemViewProvider provider)
    {
        _factory = factory;
        _itemFactory = itemFactory;
        _itemProvider = provider;
    }
    
    public override void InstallBindings()
    {
        var viewAnimal = _factory.Create(_spawnPointAnimal);
        viewAnimal.transform.localScale *= Size;

        if (viewAnimal.Animal.ItemView != null)
            _itemFactory.Create(viewAnimal.Animal.ItemView, viewAnimal.ItemContainer);
        
        Container
            .BindInterfacesAndSelfTo<AnimalView>()
            .FromInstance(viewAnimal)
            .AsSingle();
        
        Container
            .Bind<Animal>()
            .FromInstance(viewAnimal.Animal)
            .AsSingle();
        
        Container
            .Bind<Animator>()
            .FromInstance(viewAnimal.Animator)
            .AsSingle();
    }
}