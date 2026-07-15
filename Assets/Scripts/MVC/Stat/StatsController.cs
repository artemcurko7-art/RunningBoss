public class StatsController
{
    private readonly SkillPoint _skillPoint;

    public StatsController(SkillPoint skillPoint)
    {
        _skillPoint = skillPoint;
    }

    public void ProcessHandler(StatType type, AnimalView animalView)
    {
        if (_skillPoint.Value > 0)
        {
            animalView.Animal.Stats[type].Up();
            _skillPoint.Reduce(); 
        }
    }
}