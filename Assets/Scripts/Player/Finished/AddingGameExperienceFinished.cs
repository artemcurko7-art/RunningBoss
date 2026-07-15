public class AddingGameExperienceFinished : FinishedSubscriber
{
    private readonly IGameExperience _experience;
    private readonly ILocationLevel _locationLevel;
    private readonly ExperienceStats _stats;
    
    public AddingGameExperienceFinished(IFinished finished, IGameExperience experience, ILocationLevel locationLevel, ExperienceStats stats) : base(finished)
    {
        _experience = experience;
        _locationLevel = locationLevel;
        _stats = stats;
    }

    protected override void OnFinished()
    {   
        _experience.Add(_stats.Finished * _locationLevel.Value);
    }
}