using UnityEngine;
using Zenject;

public class QuestViewFactory
{
    private readonly QuestView _view;
    private readonly DiContainer _container;
    
    public QuestViewFactory(QuestView view, DiContainer container)
    {
        _container = container;
        _view = view;
    }

    public QuestView Create(Quest quest, RectTransform container)
    {
        var view = _container.InstantiatePrefabForComponent<QuestView>(_view, container.position, Quaternion.identity, container);
        view.Initialize(quest);

        return view;
    }
}