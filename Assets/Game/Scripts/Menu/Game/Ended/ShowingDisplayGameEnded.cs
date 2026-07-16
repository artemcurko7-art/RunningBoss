using System.Threading;
using Cysharp.Threading.Tasks;

public class ShowingDisplayGameEnded : GameEndedSubscriber
{
    private const float Cooldown = 1f;
    private readonly IGameLevelUpped _levelUpped;
    private readonly DisplayGameEnded _display;
    private readonly DisplayLevelUpped _displayLevelUpped;
    private CancellationTokenSource _cancellationTokenSource;
    private bool _isUpped;
    
    public ShowingDisplayGameEnded(IGame game, IGameLevelUpped levelUpped, DisplayGameEnded display, DisplayLevelUpped displayLevelUpped) 
        : base(game)
    {
        _levelUpped = levelUpped;
        _display = display;
        _displayLevelUpped = displayLevelUpped;
    }

    public override void Subscribe()
    {
        base.Subscribe();
        _levelUpped.Upped += OnUpped;
        
        _cancellationTokenSource = new CancellationTokenSource();
    }

    public override void Unsubscribe()
    {
        base.Unsubscribe();
        _levelUpped.Upped -= OnUpped;
        
        _cancellationTokenSource.Cancel();
    }

    protected override void OnGameEnded()
    {
        RunAsync(_cancellationTokenSource.Token).Forget();
    }

    private async UniTaskVoid RunAsync(CancellationToken token)
    {
        await UniTask.WaitForSeconds(Cooldown, cancellationToken: token);

        _display.gameObject.SetActive(true);
        
        if (_isUpped)
            _displayLevelUpped.gameObject.SetActive(true);
            
        if (token.IsCancellationRequested)
            return;
    }

    private void OnUpped()
    {
       _isUpped = true; 
    }
}