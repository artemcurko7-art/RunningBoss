using UnityEngine;
using Zenject;

public class ProgressViewFactory
{
    private readonly ProgressView _view;
    private readonly DiContainer _container;

    public ProgressViewFactory(ProgressView view, DiContainer container)
    {
        _view = view;
        _container = container;
    }

    public ProgressView Create(Progress progress, RectTransform container)
    {
        var view = _container.InstantiatePrefabForComponent<ProgressView>(_view, container.position, Quaternion.identity, container);
        view.Initialize(progress);
        
        return view;
    }
}