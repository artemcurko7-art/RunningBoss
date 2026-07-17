namespace Game.Scripts.Service.Selector.Animal.Visible
{
    public class LeftVisibleSelectorButton : VisibleSelectorButton
    {
        public override void Construct(IAnimalSelectedButton selected)
        {
            base.Construct(selected);

            Selected.LeftSelected += OnSelected;
            Selected.Update();
        }

        protected override void OnDestroy()
        {
            Selected.LeftSelected -= OnSelected;
        }
    }
}