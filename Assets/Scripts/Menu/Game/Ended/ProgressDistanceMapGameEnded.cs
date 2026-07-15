using YG;

public class ProgressDistanceMapGameEnded : GameEndedSubscriber
{
    private readonly IGame _game;
    private readonly IDistanceMap _distanceMap;
    private readonly IProgressData _data;
    
    public ProgressDistanceMapGameEnded(IGame game, IDistanceMap distanceMap, IProgressData data) : base(game)
    {
        _distanceMap = distanceMap;
        _data = data;
    }

    protected override void OnGameEnded()
    {
        ProgressType type = ProgressType.Distance;
        
        _data.Progresses[type].SetValue((int)_distanceMap.CompletedValue);
        YG2.saves.ProgressStorage(_data.Progresses[type]);
    }
}