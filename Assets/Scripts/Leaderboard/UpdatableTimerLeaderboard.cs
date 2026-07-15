using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using YG;

public class UpdatableTimerLeaderboard : MonoBehaviour
{
    private const string TotalTime = "GameTime";
    private TimerLeaderboard _timer;
    private CancellationTokenSource _cancellationTokenSource;
    private bool _isActive;
    
    [Inject]
    public void Construct(TimerLeaderboard timer)
    {
        _timer = timer;
        
        _cancellationTokenSource = new CancellationTokenSource();
    }

    private void Update()
    {
        YG2.saves.TimerLeaderboard += _timer.Timer;
        _timer.ResetTimer();
    }

    private void OnEnable()
    {
        if (_isActive == false)
        {
            YG2.saves.TimerLeaderboard += _timer.Timer;
            _timer.ResetTimer();
            YG2.SetLBTimeConvert(TotalTime, YG2.saves.TimerLeaderboard);
            YG2.GetLeaderboard(TotalTime);
            RunAsync(_cancellationTokenSource.Token).Forget();
        }
    }

    private void OnDestroy()
    {
        _cancellationTokenSource.Cancel();
    }

    private async UniTaskVoid RunAsync(CancellationToken token)
    {
        _isActive = true;
        
        await UniTask.WaitForSeconds(3, cancellationToken: token);
            
        if (token.IsCancellationRequested)
            return;
            
        _isActive = false;
    }
}