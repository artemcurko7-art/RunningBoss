using YG;

public class SwitchingToCardFinished : FinishedSubscriber
{
    private readonly GameWorldData _gameWorldData;
    
    public SwitchingToCardFinished(IFinished finished, GameWorldData gameWorldData) : base(finished)
    {
        _gameWorldData = gameWorldData;
    }

    protected override void OnFinished()
    {
        YG2.saves.IndexGameWorldConfig++;
        
        if (YG2.saves.IndexGameWorldConfig == _gameWorldData.Configs.Length)
            YG2.saves.IndexGameWorldConfig = 0;
    }
}