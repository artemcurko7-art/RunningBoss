using YG;

public class KilledProgress : KilledSubscriber
{
    private readonly IProgressData _data;
    
    public KilledProgress(IKilled killed, IProgressData data) 
        : base(killed)
    {
        _data = data;
    }

    protected override void OnKilled()
    {
        ProgressType type = ProgressType.Killed;
        
        _data.Progresses[type].SetValue(1);
        YG2.saves.ProgressStorage(_data.Progresses[type]);
    }
}