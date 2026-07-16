using YG;

public class ProgressDeath : DeathSubscriber
{
    private readonly IProgressData _data;
    
    public ProgressDeath(IDeath death, IProgressData data) 
        : base(death)
    {
        _data = data;
    }

    protected override void OnDied()
    {
        ProgressType type = ProgressType.Death;
        
        _data.Progresses[type].SetValue(1);
        YG2.saves.ProgressStorage(_data.Progresses[type]);  
    }
}