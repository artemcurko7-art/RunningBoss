using System;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class SelectorAnimalViewService : ISelectorService, ISetterSelectorAnimalService, IAnimalSelected, IAnimalSelectedButton
{
    private readonly AnimalData _data;
    private readonly AnimalProvider _provider;
    private readonly AnimalViewFactory _factory;
    private readonly Transform _container;
    private readonly List<AnimalView> _views = new ();
    private readonly List<AnimalView> _prefabs = new ();
    private int _index;

    public SelectorAnimalViewService(AnimalData data, AnimalProvider provider, AnimalViewFactory factory, Transform container)
    {
        _data = data;
        _provider = provider;
        _factory = factory;
        _container = container;

        _index = YG2.saves.SelectorAnimalViewIndex;
        Create();
    }
    
    public event Action<AnimalView> Selected;
    public event Action<AnimalView> Created;
    public event Action<bool> LeftSelected;
    public event Action<bool> RightSelected;
    
    public void OnClickLeft()
    {
        _index--;
        Select(true);
    }
    
    public void OnClickRight()
    {
        _index++;
        Select(false);
    }

    public void Update()
    {
        foreach (var view in _views)
            Created?.Invoke(view);
        
        Selected?.Invoke(_views[_index]);
        LeftSelected?.Invoke(_index == 0);
        RightSelected?.Invoke(_index == _views.Count - 1);
    }
    
    public void Set(AnimalView prefab)
    {
        var view = _factory.Create(prefab, _container);
        view.gameObject.SetActive(false);
        view.Shadow.gameObject.SetActive(true);
        
        Created?.Invoke(view);
        _prefabs.Add(prefab);
        _views.Add(view);
        
        if (YG2.saves.SelectedAnimalType == prefab.Animal.Type)
            _provider.Set(prefab, prefab.Animal);
    }

    public void SetDefault(AnimalType type)
    {
        var prefab = _data.Views[type]; 
        var view = _factory.Create(prefab, _container);
        view.Shadow.gameObject.SetActive(true);

        Created?.Invoke(view);
        _provider.Set(prefab, prefab.Animal);
        _prefabs.Add(prefab);
        _views.Add(view);
        YG2.saves.SelectedAnimalType = _views[_index].Animal.Type;
    }

    private void Create()
    {
        foreach (var type in YG2.saves.AnimalTypes)
            foreach (var view in _data.Views)
                if (type == view.Key)
                    Set(view.Value);

        if (_views.Count > 0)
        {
            _views[YG2.saves.SelectorAnimalViewIndex].gameObject.SetActive(true);
            Update();
        }
    }
    
    private void Select(bool isInvert)
    {
        if (isInvert)
            _views[_index + 1].gameObject.SetActive(false);
        else
            _views[_index - 1].gameObject.SetActive(false);
        
        _views[_index].gameObject.SetActive(true);
        _provider.Set(_prefabs[_index], _prefabs[_index].Animal);
        YG2.saves.SelectorAnimalViewIndex = _index;
        YG2.saves.SelectedAnimalType = _views[_index].Animal.Type;
        Update();
    }
}