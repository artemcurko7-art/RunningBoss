using YG;

public class SavesTrainingGameEnded : GameEndedSubscriber
{
    private readonly IGame _game;
    
    public SavesTrainingGameEnded(IGame game) 
        : base(game) { }

    protected override void OnGameEnded()
    {
        YG2.saves.IsSavesTraining = true;
    }
}
