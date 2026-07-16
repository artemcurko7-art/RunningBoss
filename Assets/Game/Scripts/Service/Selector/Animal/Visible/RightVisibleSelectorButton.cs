public class RightVisibleSelectorButton : VisibleSelectorButton
{
    public override void Construct(IAnimalSelectedButton selected)
    {
        base.Construct(selected);
        
        Selected.RightSelected += OnSelected;
        Selected.Update();
    }

    protected override void OnDestroy()
    {
        Selected.RightSelected -= OnSelected;
    }
}