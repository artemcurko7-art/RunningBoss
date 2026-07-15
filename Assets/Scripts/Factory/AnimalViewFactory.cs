using UnityEngine;
using Zenject;

public class AnimalViewFactory 
{
    private readonly IAnimalProvider _animalProvider;
    private readonly DiContainer _container;

    public AnimalViewFactory(IAnimalProvider animalProvider, DiContainer container)
    {
        _animalProvider = animalProvider;
        _container = container;
    }

    public AnimalView Create(Transform container)
    {
        var viewAnimal = _container.InstantiatePrefabForComponent<AnimalView>(_animalProvider.AnimalView, container.position, Quaternion.identity, container);
        viewAnimal.Initialize(_animalProvider.Animal);
        
        return viewAnimal;
    }
    
    public AnimalView Create(AnimalView animalView, Transform container)
    {
        var view = _container.InstantiatePrefabForComponent<AnimalView>(animalView, container.position, Quaternion.Euler(0, 134f, 0), container);
        view.Initialize(animalView.Animal);
        view.transform.localScale = animalView.transform.localScale;
        
        return view;
    }
}