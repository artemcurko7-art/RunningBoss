public class RaisingLocationLevelFinished : FinishedSubscriber
{
    private readonly ILocationLevelUpped _upped;

    public RaisingLocationLevelFinished(IFinished finished, ILocationLevelUpped upped) 
        : base(finished)
    {
        _upped = upped;
    }

    protected override void OnFinished()
    {
        _upped.UpLevel();
    }
}