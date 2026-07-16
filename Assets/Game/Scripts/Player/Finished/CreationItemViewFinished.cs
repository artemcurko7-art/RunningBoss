using UnityEngine;
using YG;

public class CreationItemViewFinished : FinishedSubscriber
{
    private const float DegreeOfOccupancy = 0.5f;
    private readonly ItemData _data;
    private readonly ItemViewService _service;
    private readonly ItemCellFactory _factory;
    private readonly IItemViewProvider _provider;
    private readonly RectTransform _container;
    
    public CreationItemViewFinished(IFinished finished, ItemData data, ItemViewService service, ItemCellFactory factory, IItemViewProvider provider, RectTransform container)
        : base(finished)
    {
        _data = data;
        _service = service;
        _factory = factory;
        _provider = provider;
        _container = container;
    }

    protected override void OnFinished()
    {
        if (_provider.View == null)
            return;

        var view = _data.Views[_provider.View.Type];
        
        view.Item.AddDegreeOfOccupancy(DegreeOfOccupancy);
        YG2.saves.InventoryItems[view.Type] += DegreeOfOccupancy;
        var cell = _factory.Create(_data.Configs[view.Type], _container, view.Item.DegreeOfOccupancy);
        cell.Selector.gameObject.SetActive(false);
        cell.GetComponent<SelectedTab>().enabled = false;
        _container.gameObject.SetActive(true);
        _service.CheckFullness();
    }
}